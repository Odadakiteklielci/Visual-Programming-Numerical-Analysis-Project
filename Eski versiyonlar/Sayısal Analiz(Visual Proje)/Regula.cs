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
    public partial class Regula : Form
    {
        string dbName = "regulatTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=regulaTablo.db;Version=3;");
        public Regula()
        {
            InitializeComponent();
        }
            
        
        public void createDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE regulagecmis(id INTEGER PRIMARY KEY AUTOINCREMENT, fonksiyon varchar(255) not null, a INTEGER not null,b INTEGER not null, sonuc DOUBLE not null, datetime DATETIME not null)";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    
        


        private double f(double x)
        {
            double e = Math.Exp(1);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return Math.Pow(x, 3) - 5 * Math.Pow(x, 2) - 2 * x + 10;
                case 1:
                    return Math.Pow(e, -x) - 2;
                default:
                    return Math.Pow(x, 3) - 5 * Math.Pow(x, 2) - 2 * x + 10;
            }
        }

        private double Hesapla(double tol, int maxIter)
        {
            double a, b;

            // Başlangıç aralığını comboBox1'e göre belirleme
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    a = 1; b = 3;
                    break;
                case 1:
                    a = -1; b = 0;
                    break;
                default:
                    a = 0; b = 1;
                    break;
            }

            // Aralığın uygunluğunu kontrol et
            if (f(a) * f(b) >= 0)
            {
                throw new ArgumentException("Aralık uygun değil: f(a) ve f(b) zıt işaretli olmalı.");
            }

            double c = a; // Başlangıçta c'yi a olarak başlatıyoruz
            int iter = 0;

            while (iter < maxIter)
            {
                // Regula Falsi formülü ile yeni c değeri hesaplama
                c = b - (f(b) * (b - a)) / (f(b) - f(a));

                // Kök bulunursa veya tolerans yeterince küçükse döngüyü sonlandır
                if (Math.Abs(f(c)) < tol || Math.Abs(b - a) < tol)
                {
                    return c;
                }

                // Yeni aralığı belirleme
                if (f(a) * f(c) < 0)
                {
                    b = c; // c kökün olduğu aralığın yeni üst sınırı
                }
                else
                {
                    a = c; // c kökün olduğu aralığın yeni alt sınırı
                }

                iter++;
            }

            // Maksimum iterasyona ulaşıldığında sonuç döndürülür
            return c;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            try
            {
                RegulaSQL regulaSQL = null;
                double tol = 0.0001; // Tolerans değeri
                int maxIter = 100;  // Maksimum iterasyon
                double root = Hesapla(tol, maxIter);
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        regulaSQL = new RegulaSQL("x^3-5x^2-2x+10", 1, 3, root, DateTime.Now);
                        break;
                    case 1:
                        regulaSQL = new RegulaSQL("e^(-x)-2", -1, 0, root, DateTime.Now);
                        break;
                    default:
                        regulaSQL = new RegulaSQL("x^3-5x^2-2x+10", 1, 3, root, DateTime.Now);
                        break;
                }

                // Veritabanına kaydetme işlemi ekleniyor
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = @"INSERT INTO regulagecmis 
                         (fonksiyon, a, b, sonuc, datetime) 
                         VALUES 
                         (@fonksiyon, @a, @b, @sonuc, @datetime)";

                cmd.Parameters.AddWithValue("@fonksiyon", regulaSQL.Fonksiyon);
                cmd.Parameters.AddWithValue("@a",regulaSQL.A);
                cmd.Parameters.AddWithValue("@b", regulaSQL.B);
                cmd.Parameters.AddWithValue("@sonuc", regulaSQL.Sonuc);
                cmd.Parameters.AddWithValue("@datetime", regulaSQL.DateTime);

                cmd.ExecuteNonQuery();




                MessageBox.Show($"Kök: {root}", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Regula_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            createDatabase();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    break;
                case 1:
                    textBox1.Text = "-1";
                    textBox2.Text = "0";
                    break;
                default:
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    break;

            }
        }
    }
}
