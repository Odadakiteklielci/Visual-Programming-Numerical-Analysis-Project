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
    public partial class Sekant : Form
    {
        string dbName = "sekantTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=sekantTablo.db;Version=3;");


        public void createDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE sekantgecmis(id INTEGER PRIMARY KEY AUTOINCREMENT, fonksiyon varchar(255) not null, x0 DOUBLE not null,x1 DOUBLE not null,iterasyonSayisi INT not null, sonuc DOUBLE not null, datetime DATETIME not null)";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        private double f(double x)
        {
            double baseValue = Math.Exp(1);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return Math.Log(x, baseValue) - Math.Exp(x);
                case 1:
                    return Math.Pow(x, 3) - 20;
                case 2:
                    return Math.Log(x, baseValue) - Math.Cos(x);
                default:
                    return Math.Log(x, baseValue) - Math.Exp(x);
            }
        }
        public Sekant()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            double x0, x1,x2;
            int iterat;
            connection.Open();

            try
            {
                SekantSQL sekantSQL = null;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        x0 = 0.5;
                        x1 = 0.6;
                        SecantMethod(x0, x1,out x2,out iterat);
                        sekantSQL = new SekantSQL("lnx-e^x", x0, x1, iterat,x2, DateTime.Now);
                        break;
                    case 1:
                        x0 = 2.5;
                        x1 = 3;
                        SecantMethod(x0, x1, out x2, out iterat);
                        sekantSQL = new SekantSQL("x^3-20", x0, x1, iterat,x2, DateTime.Now);
                        break;
                    case 2:
                        x0 = 1;
                        x1 = 1.2;
                        SecantMethod(x0, x1, out x2, out iterat);
                        sekantSQL = new SekantSQL("lnx-cos(x)", x0, x1, iterat,x2, DateTime.Now);
                        break;
                    default:
                        x0 = 0.5;
                        x1 = 0.6;
                        SecantMethod(x0, x1, out x2, out iterat);
                        sekantSQL = new SekantSQL("lnx-e^x", x0, x1, iterat,x2, DateTime.Now);
                        break;
                        

                }
                // Veritabanına kaydetme işlemi ekleniyor
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = @"INSERT INTO sekantgecmis 
                         (fonksiyon, x0, x1, iterasyonSayisi, sonuc, datetime) 
                         VALUES 
                         (@fonksiyon, @x0, @x1, @iterasyonSayisi, @sonuc, @datetime)";

                cmd.Parameters.AddWithValue("@fonksiyon", sekantSQL.Fonksiyon);
                cmd.Parameters.AddWithValue("@x0", sekantSQL.X0);
                cmd.Parameters.AddWithValue("@x1", sekantSQL.X1);
                cmd.Parameters.AddWithValue("@iterasyonSayisi", sekantSQL.IterasyonSayisi);
                cmd.Parameters.AddWithValue("@sonuc", sekantSQL.Sonuc);
                cmd.Parameters.AddWithValue("@datetime", sekantSQL.DateTime);

                cmd.ExecuteNonQuery();

                MessageBox.Show($"Kök bulundu: {x2} (İterasyon sayısı: {iterat + 1})");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            
           
            


            // Sekant yöntemini başlat
            
        }
        private void SecantMethod(double x0, double x1,out double x2,out int iteration)
        {
            double tol = 1e-6; // Hata toleransı (yaklaşık kök)
            x2 = 0; // Yeni kök tahmini

            iteration = 0;

            // Kök bulunana kadar iterasyon yap
            while (true)
            {
                // Sekant yöntemi formülü
                x2 = x1 - (f(x1) * (x1 - x0)) / (f(x1) - f(x0));

                // Kök bulunduğunda veya tolerans sağlandığında dur
                if (Math.Abs(x2 - x1) < tol)
                {
                    
                    return;
                }

                // İterasyonları güncelle
                x0 = x1;
                x1 = x2;

                iteration++;

                // Kök bulunmadıysa döngü devam eder
            }
        }
        private void Sekant_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            createDatabase();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = "0.5";
                    textBox2.Text = "0.6";
                    break;
                case 1:
                    textBox1.Text = "2.5";
                    textBox2.Text = "3";
                    break;
                case 2:
                    textBox1.Text = "1";
                    textBox2.Text = "1.2";
                    break;
                default:
                    textBox1.Text = "0.5";
                    textBox2.Text = "0.6";
                    break;

            }
        }
    }
}
