using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sayısal_Analiz_Visual_Proje_
{
    public partial class Tablo : Form
    {
        private List<double> x;
        private List<double> y;
        private int noktasayisi;
        public Tablo(List<double> x, List<double> y)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
            noktasayisi = x.Count;
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
        public void ShowDeltaTable(List<double> x, List<double> y)
        {
            // Tablo formunu oluşturun ve gösterin

            int n = x.Count;
            double[,] Dky = Delta(x, y);

            // DataGridView'i sıfırlayın
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Sütun başlıklarını ekleyin
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add($"Column{i}", $"Δ^{i}y");
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;  // Otomatik genişlik
            }

            // Delta tablosunu DataGridView'e ekleyin
            for (int i = 0; i < n; i++)
            {
                var row = new DataGridViewRow();
                for (int j = 0; j < n; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Dky[i, j] });
                }
                dataGridView1.Rows.Add(row);
            }

            // Formu yeniden boyutlandırarak veri tablosunu daha iyi gösterme
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();


            

            
        }


        private void AutoSizeDataGridView()
        {
            // Form başlık çubuğu yüksekliği
            int titleBarHeight = SystemInformation.CaptionHeight +
                                SystemInformation.BorderSize.Height +
                                SystemInformation.BorderSize.Height;

            // Label (Delta Tablosu) için değişkenler
            Label titleLabel;
            int labelHeight = 40; // Label yüksekliği
            int labelMargin = 10; // Label ile DataGridView arası boşluk

            // Label'ı bul veya oluştur
            if (this.Controls.Find("labelTitle", true).Length > 0)
            {
                titleLabel = (Label)this.Controls.Find("labelTitle", true)[0];
            }
            else
            {
                titleLabel = new Label();
                titleLabel.Name = "labelTitle";
                titleLabel.Text = "Delta Tablosu";
                titleLabel.Font = new Font(titleLabel.Font.FontFamily, 16, FontStyle.Regular);
                titleLabel.AutoSize = false;
                titleLabel.Height = labelHeight;
                titleLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(titleLabel);
            }

            // DataGridView ayarları
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.MinimumWidth = 100;
                col.FillWeight = 100;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // DataGridView yüksekliğini hesapla
            int totalHeight = dataGridView1.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalHeight += row.Height;
            }

            if (dataGridView1.ScrollBars == ScrollBars.Vertical ||
                dataGridView1.ScrollBars == ScrollBars.Both)
            {
                totalHeight += SystemInformation.HorizontalScrollBarHeight;
            }

            // Kenar boşlukları
            int horizontalMargin = 40;
            int verticalMargin = 20;
            int buttonSpace = 50;

            // Label'ı konumlandır
            titleLabel.Location = new Point(horizontalMargin / 2, verticalMargin);
            titleLabel.Width = this.ClientSize.Width - horizontalMargin;

            // DataGridView'i Label'ın altına konumlandır
            dataGridView1.Location = new Point(
                horizontalMargin / 2,
                titleLabel.Bottom + labelMargin
            );
            dataGridView1.Width = this.ClientSize.Width - horizontalMargin;
            dataGridView1.Height = totalHeight;

            // Form boyutunu ayarla
            this.Size = new Size(
                dataGridView1.Width + horizontalMargin + (SystemInformation.BorderSize.Width * 2),
                totalHeight + labelHeight + buttonSpace + (verticalMargin * 2) + labelMargin + titleBarHeight
            );

            // Buton konumunu ayarla
            if (this.Controls.Find("button1", true).Length > 0)
            {
                Button button = (Button)this.Controls.Find("button1", true)[0];
                button.Location = new Point(
                    (this.ClientSize.Width - button.Width) / 2,
                    dataGridView1.Bottom + 10
                );
            }

            // DataGridView ve Label için Anchor ayarları
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            titleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IleriYon ileri = new IleriYon(x, y);
            ileri.Show();
        }

        private void Tablo_Load(object sender, EventArgs e)
        {

            ShowDeltaTable(x,y);
            AutoSizeDataGridView();
        }
    }
}
