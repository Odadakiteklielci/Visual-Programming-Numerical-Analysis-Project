namespace Sayısal_Analiz_Visual_Proje_
{
    partial class Hakkında
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
            ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label2 = new Label();
            label6 = new Label();
            label3 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ıconPictureBox1
            // 
            ıconPictureBox1.BackColor = SystemColors.Control;
            ıconPictureBox1.ForeColor = SystemColors.ActiveCaption;
            ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Info;
            ıconPictureBox1.IconColor = SystemColors.ActiveCaption;
            ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox1.IconSize = 112;
            ıconPictureBox1.Location = new Point(187, 57);
            ıconPictureBox1.Name = "ıconPictureBox1";
            ıconPictureBox1.Size = new Size(122, 112);
            ıconPictureBox1.TabIndex = 0;
            ıconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(66, 316);
            label1.Name = "label1";
            label1.Size = new Size(312, 34);
            label1.TabIndex = 1;
            label1.Text = "Geliştirici: Harun Kaya";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(57, 362);
            label4.Name = "label4";
            label4.Size = new Size(227, 34);
            label4.TabIndex = 4;
            label4.Text = "Yapım Yılı: 2024";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(95, 407);
            label5.Name = "label5";
            label5.Size = new Size(116, 34);
            label5.TabIndex = 5;
            label5.Text = "İletişim:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 224);
            label2.Name = "label2";
            label2.Size = new Size(460, 20);
            label2.TabIndex = 6;
            label2.Text = "Bu yazılım, sayısal analizler yaparak veritabanına kaydeder ve önceki";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 244);
            label6.Name = "label6";
            label6.Size = new Size(195, 20);
            label6.TabIndex = 8;
            label6.Text = "analizlere hızlı erişim sağlar.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(204, 415);
            label3.Name = "label3";
            label3.Size = new Size(291, 22);
            label3.TabIndex = 9;
            label3.Text = "ahmetharun.kaya@hotmail.com";
            // 
            // button1
            // 
            button1.Location = new Point(204, 483);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Kapat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Hakkında
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 538);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(ıconPictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Hakkında";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label2;
        private Label label6;
        private Label label3;
        private Button button1;
    }
}