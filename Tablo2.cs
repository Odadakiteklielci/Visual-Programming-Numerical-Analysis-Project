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
    public partial class Tablo2 : Form
    {
        private List<double> x;
        private List<double> y;
        private int noktasayisi;
        UserSQL UserSQL;

        public Tablo2(List<double> x, List<double> y, UserSQL userSQL)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
            noktasayisi = x.Count;
            UserSQL = userSQL;
        }

        public double[,] Delta(List<double> x, List<double> y)
        {
            if (x.Count != y.Count)
            {
                throw new ArgumentException("x ve y dizilerinin uzunlukları eşit olmalıdır.");
            }

            int n = x.Count;
            double[,] Dky = new double[n, n];

            // İlk sütuna y değerlerini sondan başa doğru yerleştir
            for (int i = 0; i < n; i++)
            {
                Dky[i, 0] = y[n - 1 - i];
            }

            // Geri farkları hesapla
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    // Geri fark formülü: sadece değerlerin farkını al, bölme işlemi yapma
                    Dky[i, j] = Dky[i, j - 1] - Dky[i + 1, j - 1];
                }
            }

            return Dky;
        }

        public void ShowDeltaTable(List<double> x, List<double> y)
        {
            int n = x.Count;
            double[,] Dky = Delta(x, y);

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // X değerleri için sütun ekle
            dataGridView1.Columns.Add("X", "x");
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Y değerleri ve farklar için sütunlar ekle
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add($"Column{i}", $"∇^{i}f");
                dataGridView1.Columns[i + 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Verileri ekle
            for (int i = 0; i < n; i++)
            {
                var row = new DataGridViewRow();

                // X değerlerini doğru sırasıyla ekle (normal sıralama)
                row.Cells.Add(new DataGridViewTextBoxCell { Value = x[i] });

                // Farkları ekle
                for (int j = 0; j < n - i; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Math.Round(Dky[i, j], 6) });
                }

                // Kalan hücreleri boş bırak
                for (int j = n - i; j < n; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                }

                // Satırı başa eklemek için Insert(0, row) kullanma
                dataGridView1.Rows.Add(row);  // Normal sırayla ekleme
            }

            // Tablonun kolonlarını yeniden düzenle
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }





        private void AutoSizeDataGridView()
        {
            // [AutoSizeDataGridView metodu aynı kalacak]
            int titleBarHeight = SystemInformation.CaptionHeight +
                                SystemInformation.BorderSize.Height +
                                SystemInformation.BorderSize.Height;

            Label titleLabel;
            int labelHeight = 40;
            int labelMargin = 10;

            if (this.Controls.Find("labelTitle", true).Length > 0)
            {
                titleLabel = (Label)this.Controls.Find("labelTitle", true)[0];
            }
            else
            {
                titleLabel = new Label();
                titleLabel.Name = "labelTitle";
                titleLabel.Text = "Geri Fark Tablosu";
                titleLabel.Font = new Font(titleLabel.Font.FontFamily, 16, FontStyle.Regular);
                titleLabel.AutoSize = false;
                titleLabel.Height = labelHeight;
                titleLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(titleLabel);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.MinimumWidth = 100;
                col.FillWeight = 100;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

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

            int horizontalMargin = 40;
            int verticalMargin = 20;
            int buttonSpace = 50;

            titleLabel.Location = new Point(horizontalMargin / 2, verticalMargin);
            titleLabel.Width = this.ClientSize.Width - horizontalMargin;

            dataGridView1.Location = new Point(
                horizontalMargin / 2,
                titleLabel.Bottom + labelMargin
            );
            dataGridView1.Width = this.ClientSize.Width - horizontalMargin;
            dataGridView1.Height = totalHeight;

            this.Size = new Size(
                dataGridView1.Width + horizontalMargin + (SystemInformation.BorderSize.Width * 2),
                totalHeight + labelHeight + buttonSpace + (verticalMargin * 2) + labelMargin + titleBarHeight
            );

            if (this.Controls.Find("button1", true).Length > 0)
            {
                Button button = (Button)this.Controls.Find("button1", true)[0];
                button.Location = new Point(
                    (this.ClientSize.Width - button.Width) / 2,
                    dataGridView1.Bottom + 10
                );
            }

            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            titleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeriYon geri = new GeriYon(x, y,UserSQL);
            geri.Show();
        }

        private void Tablo_Load(object sender, EventArgs e)
        {
            ShowDeltaTable(x, y);
            AutoSizeDataGridView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GeriYon geri = new GeriYon(x, y,UserSQL);
            geri.Show();
        }

        private void Tablo2_Load(object sender, EventArgs e)
        {
            ShowDeltaTable(x, y);
            AutoSizeDataGridView();
        }
    }
}