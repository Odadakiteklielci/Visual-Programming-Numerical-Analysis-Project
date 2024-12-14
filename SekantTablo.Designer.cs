namespace Sayısal_Analiz_Visual_Proje_
{
    partial class SekantTablo
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
            baslik = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // baslik
            // 
            baslik.Anchor = AnchorStyles.Top;
            baslik.AutoSize = true;
            baslik.Font = new Font("Lucida Sans Unicode", 36F, FontStyle.Regular, GraphicsUnit.Point, 162);
            baslik.ForeColor = SystemColors.GradientActiveCaption;
            baslik.Location = new Point(438, -7);
            baslik.Name = "baslik";
            baslik.Size = new Size(454, 73);
            baslik.TabIndex = 6;
            baslik.Text = "Sekant Geçmiş";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-2, 72);
            dataGridView1.Margin = new Padding(3, 73, 3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1413, 101);
            dataGridView1.TabIndex = 5;
            // 
            // SekantTablo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 177);
            Controls.Add(baslik);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SekantTablo";
            Text = "SekantTablo";
            Load += SekantTablo_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label baslik;
        private DataGridView dataGridView1;
    }
}