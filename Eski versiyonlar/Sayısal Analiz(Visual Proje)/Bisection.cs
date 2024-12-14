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
    public partial class Bisection : Form
    {
        string dbName = "bisectionTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=bisectionTablo.db;Version=3;");



        public void createDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE bisectiongecmis(id INTEGER PRIMARY KEY AUTOINCREMENT, fonksiyon varchar(255) not null, a INTEGER not null,b INTEGER not null, sonuc DOUBLE not null, datetime DATETIME not null)";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        private double f(double x)
        {
            
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    
                    return Math.Pow(2, x) - 5 * x + 2;
                case 1:
                    return Math.Exp(x) - 3 * x;
                case 2:
                    return Math.Pow(x, 2) - 2;
                default:
                    return Math.Pow(2, x) - 5 * x + 2;
            }
        }

        private double Hesapla(double tol, int maxIter)
        {
            double a, b;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    a = 0; b = 1;
                    break;
                case 1:
                    a = 0; b = 1;
                    break;
                case 2:
                    a = 1; b = 2;
                    break;
                default:
                    a = 0; b = 1;
                    break;
            }
            if (f(a) * f(b) >= 0)
            {
                throw new ArgumentException("Aralık uygun değil: f(a) ve f(b) zıt işaretli olmalı.");
            }

            double c = a; // Orta nokta
            int iteration = 0;

            while ((b - a) / 2 > tol && iteration < maxIter)
            {
                c = (a + b) / 2; // Orta nokta
                double fc = f(c);

                // Kök bulunduysa
                if (fc == 0 || (b - a) / 2 < tol)
                    break;

                // İşaret değişimine göre aralığı daralt
                if (f(a) * fc < 0)
                    b = c;
                else
                    a = c;

                iteration++;
            }

            if (iteration >= maxIter)
            {
                MessageBox.Show("Maksimum iterasyon sayısına ulaşıldı. Kök hassasiyeti sağlanamadı.", "Uyarı");
            }

            return c; // Bulunan kök
        }





        public Bisection()
        {
            InitializeComponent();
        }

        private void Bisection_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            createDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            try
            {
                BisectionSQL bisectionSQL = null; // TaylorSQL nesnesini burada tanımlıyoruz
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        bisectionSQL = new BisectionSQL("2^x-5x+1", 0, 1, Hesapla(0.01, 100), DateTime.Now);
                        break;
                    case 1:
                        bisectionSQL = new BisectionSQL("e^x-3x", 0, 1, Hesapla(0.01, 100), DateTime.Now);
                        break;
                    case 2:
                        bisectionSQL = new BisectionSQL("x^2-2", 1, 2, Hesapla(0.01, 100), DateTime.Now);
                        break;
                    default:
                        bisectionSQL = new BisectionSQL("2^x-5x+1", 0, 1, Hesapla(0.01, 100), DateTime.Now);
                        break;
                }
                if (bisectionSQL != null)
                {
                    // Veritabanına ekleme işlemi
                    SQLiteCommand cmd = new SQLiteCommand(connection);
                    cmd.CommandText = @"INSERT INTO bisectiongecmis 
                                ( fonksiyon, a, b, sonuc, datetime) 
                                VALUES 
                                (@fonksiyon, @a, @b, @sonuc, @datetime)";

                    cmd.Parameters.AddWithValue("@fonksiyon", bisectionSQL.Fonksiyon);
                    cmd.Parameters.AddWithValue("@a", bisectionSQL.A);
                    cmd.Parameters.AddWithValue("@b", bisectionSQL.B);
                    cmd.Parameters.AddWithValue("@sonuc", bisectionSQL.Sonuc);
                    cmd.Parameters.AddWithValue("@datetime", bisectionSQL.DateTime);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            MessageBox.Show($"Kök {Hesapla(0.01, 100)} olarak hesaplanır. ");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
