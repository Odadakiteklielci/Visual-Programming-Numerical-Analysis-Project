using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Sayısal_Analiz_Visual_Proje_
{
    public partial class NoktaSec : Form
    {
        double bilgi;
        UserSQL userSQL;
        public NoktaSec(double bilgi, UserSQL userSQL)
        {
            InitializeComponent();
            this.bilgi = bilgi;
            this.userSQL = userSQL;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int noktaSayisi = 0, konumX = 161, kx = 5, label = 2,sayi=2;
        public List<double> x = new List<double>();
        public List<double> y = new List<double>();


        private void labelolustur(int sayi)
        {



            // Create new label
            Label newLabel = new Label();

            // Set label properties
            newLabel.Name = $"lb{sayi}";
            newLabel.Text = sayi.ToString();
            newLabel.Width = 50; // Optional: set a default width

            // Adjust x-coordinate

            newLabel.Location = new Point(konumX, 59);
            this.AutoSize = true;
            // Add label to form
            this.Controls.Add(newLabel);
        }

        private void textBoxOlustur(int sayi1)
        {
            
            kx += 68;
            TextBox newtext = new TextBox();
            newtext.Name = $"txt{sayi1}";
            newtext.Width = 62;
            newtext.Location = new Point(kx, 82);
           
                ;
            this.Controls.Add(newtext);



            TextBox newtex = new TextBox();
            newtex.Name = $"txty{sayi1}";
            newtex.Width = 62;
            newtex.Location = new Point(kx, 115);
            

            this.Controls.Add(newtex);

        }

        private void noktaArtir()
        {
            labelolustur(label);
            textBoxOlustur(noktaSayisi);
            noktaSayisi++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label++;
            if (noktaSayisi <= 23)
            {
                konumX += 68;
                noktaArtir();

            }
        }
        public static double CustomConvertToDouble(string input)
        {
            // Eğer input null ise 0 döndür
            if (string.IsNullOrEmpty(input))
                return 0;

            // Hem noktayı hem virgülü destekle
            if (input.Contains(','))
                input = input.Replace(',', '.'); // Virgülleri noktaya çevir

            return Convert.ToDouble(input, System.Globalization.CultureInfo.InvariantCulture);
        }

        //string xContent = string.Join(", ", x);
        //string yContent = string.Join(", ", y);


        //MessageBox.Show($"x Listesi: {xContent}\n\n y Listesi: {yContent}");
        private void button2_Click(object sender, EventArgs e)
        {
            sayi++;

            bool hataVar = false;

            // Önce x ve y listelerini temizle
            x.Clear();
            y.Clear();

            // TextBox'lar için kontrol ve listeye ekleme
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    string name = textBox.Name;

                    // Text dolu mu ve sayısal değer mi kontrol et
                    if (string.IsNullOrEmpty(textBox.Text) || !double.TryParse(textBox.Text, out double value))
                    {
                        hataVar = true;
                        break;
                    }

                    // "txt" ve "txty" TextBox'larını listeye ekle
                    if (name.StartsWith("txt") && int.TryParse(name.Substring(3), out _))
                    {
                        x.Add(value);
                    }
                    else if (name.StartsWith("txty") && int.TryParse(name.Substring(4), out _))
                    {
                        y.Add(value);
                    }
                }
            }

            // Hata varsa işlem durdurulacak
            if (hataVar)
            {
                MessageBox.Show("Lütfen tüm alanlara geçerli sayısal değerler girin.");
                return;
            }


            //string xContent = string.Join(", ", x);
            //string yContent = string.Join(", ", y);


            //MessageBox.Show($"x Listesi: {xContent}\n\n y Listesi: {yContent}");
            //Hata yoksa switch case ile ilgili formu aç
            switch (bilgi)
                {
                    case 3:
                        Tablo tablo = new Tablo(x, y, userSQL);
                        tablo.Show();
                        break;
                    case 3.1:
                        Tablo2 tablo2 = new Tablo2(x, y, userSQL);
                        tablo2.Show();
                        break;
                    case 4:
                        Lagrange lagrange = new Lagrange(x, y, userSQL); // x ve y listelerini constructor ile gönderiyoruz
                        lagrange.Show();
                        break;
                }
            }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lagrange_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                noktaArtir();
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
