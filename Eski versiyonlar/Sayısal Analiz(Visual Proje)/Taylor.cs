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
    public partial class Taylor : Form
    {
        string dbName = "taylorTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=taylorTablo.db;Version=3;");

        public Taylor()
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
                command.CommandText = "CREATE TABLE taylorgecmis(id INTEGER PRIMARY KEY AUTOINCREMENT, fonksiyon varchar(255) not null, x0 DOUBLE not null,x DOUBLE not null,iterasyonSayisi INT not null, sonuc DOUBLE not null,gercekdeger DOUBLE not null, hata DOUBLE not null, datetime DATETIME not null)";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            createDatabase();
        }

        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Faktöriyel negatif sayılar için tanımsızdır.");

            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private double  etaylor(double x0,int iterasyonSayi,double x )
        {
            double toplam = 0;
            for (int i = 0; i < iterasyonSayi; i++) {
                toplam += (Math.Pow(x - x0, i)*Math.Exp(x0))/Factorial(i);
            }
            return toplam;
        }
        private double dtaylor(double x0, int iterasyonSayi, double x)
        {
            double toplam = 0;
            for (int i = 0; i < iterasyonSayi; i++)
            {
                // Katsayıyı kontrol et
                double katsayi = Math.Pow(-4, i / 2);  // veya başka bir katsayı formülü

                if (i % 2 == 0)
                {
                    toplam += (katsayi * Math.Pow(x - x0, i)) / Factorial(i);

                }
            }
            return toplam;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            try
            {
                TaylorSQL taylorSQL = null; // TaylorSQL nesnesini burada tanımlıyoruz

                if (comboBox1.SelectedIndex == 0)
                {
                    double x0 = (double)numericUpDown2.Value;
                    int iterations = (int)numericUpDown1.Value;
                    double x = (double)numericUpDown3.Value;
                    double taylorValue = etaylor(x0, iterations, x);
                    double realValue = Math.Exp(x);
                    double hata = Math.Abs(realValue - taylorValue);
                    taylorSQL = new TaylorSQL("e^x", x0, x, iterations, taylorValue, realValue, hata, DateTime.Now);
                    
                    MessageBox.Show($"Hesaplanan değer: {taylorValue}\nGerçek değer: {realValue}\nHata: {hata}");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    double x0 = (double)numericUpDown2.Value;
                    int iterations = (int)numericUpDown1.Value;
                    double x = (double)numericUpDown3.Value;
                    double taylorValue = dtaylor(x0, iterations, x);
                    double realValue = Math.Cos(2 * x);
                    double hata = Math.Abs(realValue - taylorValue);
                    taylorSQL = new TaylorSQL("cos(2x)", x0, x, iterations, taylorValue, realValue, hata, DateTime.Now);
                    
                    MessageBox.Show($"Hesaplanan değer: {taylorValue}\nGerçek değer: {realValue}\nHata: {hata}");
                }

                if (taylorSQL != null)
                {
                    // Veritabanına ekleme işlemi
                    SQLiteCommand cmd = new SQLiteCommand(connection);
                    cmd.CommandText = @"INSERT INTO taylorgecmis 
                                ( fonksiyon, x0, x, iterasyonSayisi, sonuc, gercekDeger, hata, datetime) 
                                VALUES 
                                (@fonksiyon, @x0, @x, @iterasyonSayisi, @sonuc, @gercekDeger, @hata, @datetime)";
                    
                    cmd.Parameters.AddWithValue("@fonksiyon", taylorSQL.fonksiyon);
                    cmd.Parameters.AddWithValue("@x0", taylorSQL.x0);
                    cmd.Parameters.AddWithValue("@x", taylorSQL.x);
                    cmd.Parameters.AddWithValue("@iterasyonSayisi", taylorSQL.iterasyonSayisi);
                    cmd.Parameters.AddWithValue("@sonuc", taylorSQL.sonuc);
                    cmd.Parameters.AddWithValue("@gercekDeger", taylorSQL.gercekDeger);
                    cmd.Parameters.AddWithValue("@hata", taylorSQL.hata);
                    cmd.Parameters.AddWithValue("@datetime", taylorSQL.DateTime);
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
        }


    }
}
