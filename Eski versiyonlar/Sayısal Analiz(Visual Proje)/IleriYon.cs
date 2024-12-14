using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sayısal_Analiz_Visual_Proje_
{
    public partial class IleriYon : Form
    {
        string dbName = "ileriYonTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=ileriYonTablo.db;Version=3;");

        private List<double> x;
        private List<double> y;
        private int noktasayisi;
        public IleriYon(List<double> x, List<double> y)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
            noktasayisi = x.Count;
        }
        public void createDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE ileriyongecmis(id INTEGER PRIMARY KEY AUTOINCREMENT,noktalar varchar(255) not null, x DOUBLE not null, sonuc DOUBLE, datetime DATETIME not null)";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public double[,] Delta(List<double> x, List<double> y)
        {
            // Dizilerin uzunluklarını kontrol et
            if (x.Count != y.Count)
            {
                throw new ArgumentException("x ve y dizilerinin uzunlukları eşit olmalıdır.");
            }

            int n = x.Count;  // Dizi uzunluğu
            double[,] Dky = new double[n, n];  // Fark tablosu matrisi

            // İlk sütuna y değerlerini koy
            for (int i = 0; i < n; i++)
            {
                Dky[i, 0] = y[i];  // Burada y[i]'ye erişim yapılır
            }

            // Diferansiyel farkları hesapla
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    Dky[i, j] = (Dky[i + 1, j - 1] - Dky[i, j - 1]) / (x[i + j] - x[i]);
                }
            }

            return Dky;
        }



        public double Pn(List<double> x, List<double> y)
        {
            double[,] Dky = Delta(x, y);
            double sonuc = Dky[0, 0];  // İlk değer başlangıç noktası
            double carpim = 1;


            // Her bir terim için hesaplama
            for (int k = 1; k < noktasayisi; k++)
            {
                carpim *= (CustomConvertToDouble(textBox1.Text) - x[k - 1]);
                sonuc += Dky[0, k] * carpim;
            }


            return sonuc;
        }
        public static double CustomConvertToDouble(string input)
        {
            // Hem noktayı hem virgülü destekle
            if (input.Contains(','))
                input = input.Replace(',', '.'); // Virgülleri noktaya çevir

            return Convert.ToDouble(input, System.Globalization.CultureInfo.InvariantCulture);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                string noktalar = "";
                double xi = CustomConvertToDouble(textBox1.Text);

                for (int i = 0; i < x.Count; i++)
                {
                    noktalar += $"({x[i]},{y[i]})";
                    if (i < x.Count - 1)
                    {
                        noktalar += ", ";
                    }
                }
                IleriYonSQL ileriYonSQL = new IleriYonSQL(noktalar, xi, Pn(x, y), DateTime.Now);
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = @"INSERT INTO ileriyongecmis 
                         (noktalar, x, sonuc, datetime) 
                         VALUES 
                         (@noktalar, @x, @sonuc, @datetime)";

                cmd.Parameters.AddWithValue("@noktalar", ileriYonSQL.Noktalar);
                cmd.Parameters.AddWithValue("@x", ileriYonSQL.InterpolasyonNoktasi);
                cmd.Parameters.AddWithValue("@sonuc", ileriYonSQL.Sonuc);
                cmd.Parameters.AddWithValue("@datetime", ileriYonSQL.DateTime);

                cmd.ExecuteNonQuery();

                MessageBox.Show($"Girdiğiniz Bütün değerler dikkate alındığında P{x.Count}(" + CustomConvertToDouble(textBox1.Text) + ")=" + Pn(x, y));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void IleriYon_Load(object sender, EventArgs e)
        {
            createDatabase();
        }
    }
}
