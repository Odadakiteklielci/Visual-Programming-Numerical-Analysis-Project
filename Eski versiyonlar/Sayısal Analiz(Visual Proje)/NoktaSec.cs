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
        public NoktaSec(double bilgi)
        {
            InitializeComponent();
            this.bilgi = bilgi;
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
            newtext.Leave += Newtext_Leave1;
           
            newtext.TextChanged += Newtext_TextChanged2
                ;
            this.Controls.Add(newtext);



            TextBox newtex = new TextBox();
            newtex.Name = $"txty{sayi1}";
            newtex.Width = 62;
            newtex.Location = new Point(kx, 115);
            newtex.Leave += Newtex_Leave2;
            
            newtex.TextChanged += degistex; 

            this.Controls.Add(newtex);

        }
        private string previousValue = "";  // TextBox'tan önceki değer
       

        private void Newtext_Leave1(object? sender, EventArgs e)
        {
            // TextBox'lar için geçerli sayısal değerler kontrolü
            bool hataVar = false;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    // Boş bırakılmış alanı geçiyoruz
                    if (string.IsNullOrEmpty(control.Text)) continue;

                    // Sayısal değer kontrolü
                    if (!double.TryParse(control.Text, out _))
                    {
                        hataVar = true;
                        break;
                    }
                }
            }

            if (hataVar)
            {
                MessageBox.Show("Lütfen tüm alanlara geçerli sayısal değerler girin.");
                return; // İşlemi durdur
            }

            TextBox currentTextBox = sender as TextBox;
            if (currentTextBox != null)
            {
                int index = int.Parse(currentTextBox.Name.Replace("txt", "")); // 'txt' kısmını çıkarıp sayı kısmını alıyoruz

                // Geçerli değeri alıp x listesine ekle
                if (double.TryParse(currentTextBox.Text, out double result))
                {
                    // Eğer geçerli bir sayı ise, x listesine ekle
                    if (index < x.Count) // Eğer indeks mevcutsa, var olan değeri güncelle
                        x[index] = result;
                    else // Yeni bir değer ekle
                        x.Add(result);

                }
            }
        }

        private void Newtex_Leave2(object? sender, EventArgs e)
        {
            bool hataVar = false;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text)) continue;
                    if (!double.TryParse(control.Text, out _))
                    {
                        hataVar = true;
                        break;
                    }
                }
            }

            if (hataVar)
            {
                MessageBox.Show("Lütfen tüm alanlara geçerli sayısal değerler girin.");
                return;
            }

            TextBox currentTextBox = sender as TextBox;
            if (currentTextBox != null)
            {
                int index = int.Parse(currentTextBox.Name.Replace("txty", "")); // 'txty' kısmını çıkarıp sayı kısmını alıyoruz

                // Geçerli değeri alıp y listesine ekle
                if (double.TryParse(currentTextBox.Text, out double result))
                {
                    // Eğer geçerli bir sayı ise, y listesine ekle
                    if (index < y.Count) // Eğer indeks mevcutsa, var olan değeri güncelle
                        y[index] = result;
                    else // Yeni bir değer ekle
                        y.Add(result);

                }
            }
        }


        private void degistex(object? sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            int index = int.Parse(currentTextBox.Name.Replace("txty", "")); // 'txt' kısmını çıkarıp sayı kısmını alıyoruz
            if (index >= 1)
            {
                DisableTextBoxy(index - 1, false);

            }
            if (string.IsNullOrEmpty(currentTextBox.Text))
            {
                y.RemoveAt(index);
                DisableTextBoxy(index - 1, true);
            }

        }
        private void DisableTextBoxy(int index, bool state)
        {
            // "txt" ve index-1 ile ilgili TextBox'ı bulma
            string textBoxName = $"txty{index}";

            // TextBox'ı formun Controls koleksiyonunda arıyoruz
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && control.Name == textBoxName)
                {
                    control.Enabled = state;
                    break;
                }
            }
        }
        private void DisableTextBox(int index, bool state)
        {
            // "txt" ve index-1 ile ilgili TextBox'ı bulma
            string textBoxName = $"txt{index}";

            // TextBox'ı formun Controls koleksiyonunda arıyoruz
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && control.Name == textBoxName)
                {
                    control.Enabled = state; 
                    break;
                }
            }
        }

        private void Newtext_TextChanged2(object? sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            int index = int.Parse(currentTextBox.Name.Replace("txt", "")); // 'txt' kısmını çıkarıp sayı kısmını alıyoruz
            if(index >= 1)
            {
                DisableTextBox(index - 1,false);
            }
            if (string.IsNullOrEmpty(currentTextBox.Text))
            {
                   x.RemoveAt(index);
                    DisableTextBox(index-1,true);
            }


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
        private void button2_Click(object sender, EventArgs e)
        {
            
            sayi++;

            bool hataVar = false;

            // TextBox'lar için kontrol
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        hataVar = true;
                        break;
                    }

                    if (!double.TryParse(control.Text, out _))
                    {
                        hataVar = true;
                        break;
                    }
                }   
            }
            if (hataVar)
            {
                MessageBox.Show("Lütfen tüm alanlara geçerli sayısal değerler girin.");
                return; // İşlemi durdur
            }
            //string xContent = string.Join(", ", x);
            //string yContent = string.Join(", ", y);


            //MessageBox.Show($"x Listesi: {xContent}\n\n y Listesi: {yContent}");

            switch (bilgi)
            {
                case 3:
                    Tablo tablo = new Tablo(x, y);
                    tablo.Show();
                    break;
                case 3.1:
                    Tablo2 tablo2 = new Tablo2(x, y);
                    tablo2.Show();
                    break;
                case 4:
                    Lagrange lagrange = new Lagrange(x, y);  // x ve y listelerini constructor ile gönderiyoruz
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
