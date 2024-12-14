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
    public partial class GeriYon : Form
    {
        string dbName = "geriYonTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=geriYonTablo.db;Version=3;");

        private List<double> x;
        private List<double> y;
        private int noktasayisi;
        UserSQL userSQL;

        public GeriYon(List<double> x, List<double> y, UserSQL userSQL)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
            noktasayisi = x.Count;
            this.userSQL = userSQL;
        }

        public void createDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE geriyongecmis(id INTEGER PRIMARY KEY AUTOINCREMENT,noktalar varchar(255) not null, x DOUBLE not null, sonuc DOUBLE, datetime DATETIME not null, username varchar(255) not null)";
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

            // İlk sütuna y değerlerini koy - geri fark için sondan başlayarak
            for (int i = 0; i < n; i++)
            {
                Dky[i, 0] = y[n - 1 - i];  // Değerleri sondan başa doğru yerleştir
            }

            // Geri diferansiyel farkları hesapla
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    // Geri fark formülü: f[xn, xn-1, ..., xn-k] = (f[xn, xn-1, ..., xn-k+1] - f[xn-1, xn-2, ..., xn-k]) / (xn - xn-k)
                    Dky[i, j] = (Dky[i, j - 1] - Dky[i + 1, j - 1]) / (x[n - 1 - i] - x[n - 1 - (i + j)]);
                }
            }

            return Dky;
        }

        public double Pn(List<double> x, List<double> y)
        {
            double[,] Dky = Delta(x, y);
            double sonuc = Dky[0, 0];  // Son nokta başlangıç noktası olacak
            double carpim = 1;

            // Geri fark interpolasyon formülü
            for (int k = 1; k < noktasayisi; k++)
            {
                carpim *= (CustomConvertToDouble(textBox1.Text) - x[noktasayisi - k]);
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

        }

        private void button1_Click_1(object sender, EventArgs e)
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
                GeriYonSQL geriYonSQL = new GeriYonSQL(noktalar, xi, Pn(x, y), DateTime.Now);
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = @"INSERT INTO geriyongecmis 
                         (noktalar, x, sonuc, datetime,username) 
                         VALUES 
                         (@noktalar, @x, @sonuc, @datetime,@username)";

                cmd.Parameters.AddWithValue("@noktalar", geriYonSQL.Noktalar);
                cmd.Parameters.AddWithValue("@x", geriYonSQL.InterpolasyonNoktasi);
                cmd.Parameters.AddWithValue("@sonuc", geriYonSQL.Sonuc);
                cmd.Parameters.AddWithValue("@datetime", geriYonSQL.DateTime);
                cmd.Parameters.AddWithValue("@username", userSQL.Username);

                cmd.ExecuteNonQuery();

                MessageBox.Show($"Girdiğiniz Bütün değerler dikkate alındığında P{x.Count}(" +
                         CustomConvertToDouble(textBox1.Text) + ")=" + Pn(x, y));
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

        private void GeriYon_Load(object sender, EventArgs e)
        {
            createDatabase();
        }
    }
}