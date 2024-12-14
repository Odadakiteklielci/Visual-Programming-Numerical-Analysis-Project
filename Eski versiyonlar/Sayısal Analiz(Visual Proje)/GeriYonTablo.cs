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
    public partial class GeriYonTablo : Form
    {
        private SQLiteConnection connection;
        public GeriYonTablo()
        {
            InitializeComponent();
            connection = new SQLiteConnection("Data Source=geriYonTablo.db;Version=3;");
        }

        private void GeriYonTablo_Load(object sender, EventArgs e)
        {
            LoadData();
            AutoSizeDataGridView();
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


        private void LoadData()
        {
            try
            {
                connection.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM geriyongecmis", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);



                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
