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
    public partial class Lagrange : Form
    {
        string dbName = "lagrangeTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=lagrangeTablo.db;Version=3;");

        private List<double> x;
        private List<double> y;
        private int noktasayisi;
        public Lagrange(List<double> x, List<double> y)
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
                command.CommandText = "CREATE TABLE lagrangegecmis(id INTEGER PRIMARY KEY AUTOINCREMENT,noktalar varchar(255) not null, x DOUBLE not null, sonuc DOUBLE, datetime DATETIME not null)";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        private double lagHesap()
        {

            int n = noktasayisi - 1;
            double a = CustomConvertToDouble(textBox1.Text);

            // Liste boyutlarını kontrol et
            if (x.Count != noktasayisi || y.Count != noktasayisi)
            {
                MessageBox.Show("x ve y listelerinin boyutları nokta sayısı ile uyuşmuyor.");
                return 0;
            }

            // Eğer yalnızca 2 nokta varsa doğrusal interpolasyon yapılır
            if (n == 1)
            {
                if (x.Count == 2 && y.Count == 2)
                {
                    double x0 = x[0], x1 = x[1], y0 = y[0], y1 = y[1];
                    double dsonuc = y0 + ((a - x0) / (x1 - x0)) * (y1 - y0);
                    return dsonuc;
                }
                else
                {
                    MessageBox.Show("x ve y listelerinin boyutu 2 olmalıdır.");
                    return 0;
                }
            }

            // Diğer durumlar (Lagrange interpolasyonu için)
            double sonuc = 0;
            for (int k = 0; k <= n; k++)
            {
                if (k >= x.Count || k >= y.Count)
                {
                    MessageBox.Show("Geçersiz indeks erişimi (k).");
                    return 0;
                }

                double carpim = 1;
                for (int j = 0; j <= n; j++)
                {
                    if (j >= x.Count || j >= y.Count)
                    {
                        MessageBox.Show("Geçersiz indeks erişimi (j).");
                        return 0;
                    }

                    if (j != k)
                        carpim *= (a - x[j]) / (x[k] - x[j]);
                }
                sonuc += carpim * y[k];
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
                LagrangeSQL lagrangeSQL = new LagrangeSQL(noktalar, xi, lagHesap(), DateTime.Now);
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = @"INSERT INTO lagrangegecmis 
                         (noktalar, x, sonuc, datetime) 
                         VALUES 
                         (@noktalar, @x, @sonuc, @datetime)";

                cmd.Parameters.AddWithValue("@noktalar", lagrangeSQL.Noktalar);
                cmd.Parameters.AddWithValue("@x", lagrangeSQL.InterpolasyonNoktasi);
                cmd.Parameters.AddWithValue("@sonuc", lagrangeSQL.Sonuc);
                cmd.Parameters.AddWithValue("@datetime", lagrangeSQL.DateTime);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Girdiğiniz Bütün değerler dikkate alındığında P(" + xi + ")=" + lagHesap());
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

        private void Lagrange_Load(object sender, EventArgs e)
        {
            createDatabase();
        }
    }
}
