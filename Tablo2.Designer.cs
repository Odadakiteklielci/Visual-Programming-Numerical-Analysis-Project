namespace Sayısal_Analiz_Visual_Proje_
{
    partial class Tablo2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            baslik = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 71);
            dataGridView1.Margin = new Padding(3, 73, 3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(852, 326);
            dataGridView1.TabIndex = 0;
            // 
            // baslik
            // 
            baslik.Anchor = AnchorStyles.Top;
            baslik.AutoSize = true;
            baslik.Font = new Font("Lucida Sans Unicode", 36F, FontStyle.Regular, GraphicsUnit.Point, 162);
            baslik.ForeColor = SystemColors.GradientActiveCaption;
            baslik.Location = new Point(160, -5);
            baslik.Name = "baslik";
            baslik.Size = new Size(432, 73);
            baslik.TabIndex = 2;
            baslik.Text = "Delta Tablosu";
            // 
            // button1
            // 
            button1.Location = new Point(331, 403);
            button1.Name = "button1";
            button1.Size = new Size(145, 29);
            button1.TabIndex = 3;
            button1.Text = "Polinomu Kullan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Tablo2
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 450);
            Controls.Add(button1);
            Controls.Add(baslik);
            Controls.Add(dataGridView1);
            Name = "Tablo2";
            Text = "Tablo2";
            Load += Tablo2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label baslik;
        public DataGridView dataGridView1;
        private Button button1;
    }
}