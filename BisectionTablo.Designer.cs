namespace Sayısal_Analiz_Visual_Proje_
{
    partial class BisectionTablo
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
            baslik.Location = new Point(431, -6);
            baslik.Name = "baslik";
            baslik.Size = new Size(522, 73);
            baslik.TabIndex = 4;
            baslik.Text = "Bisection Geçmiş";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-2, 88);
            dataGridView1.Margin = new Padding(3, 73, 3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1402, 100);
            dataGridView1.TabIndex = 3;
            // 
            // BisectionTablo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1402, 192);
            Controls.Add(baslik);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BisectionTablo";
            Text = "BisectionTablo";
            Load += BisectionTablo_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label baslik;
        private DataGridView dataGridView1;
    }
}