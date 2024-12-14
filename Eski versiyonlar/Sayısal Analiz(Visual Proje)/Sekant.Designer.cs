namespace Sayısal_Analiz_Visual_Proje_
{
    partial class Sekant
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
            button1 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(321, 126);
            button1.Name = "button1";
            button1.Size = new Size(208, 49);
            button1.TabIndex = 5;
            button1.Text = "Hesapla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 44);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 4;
            label1.Text = "Fonksiyon Seçiniz";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "lnx-e^x", "x^3-20", "lnx-cosx" });
            comboBox1.Location = new Point(155, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 28);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 44);
            label2.Name = "label2";
            label2.Size = new Size(230, 20);
            label2.TabIndex = 6;
            label2.Text = "Başlangıç değerleri    x0            x1";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(620, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(34, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(686, 42);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(34, 27);
            textBox2.TabIndex = 8;
            // 
            // Sekant
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 220);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Sekant";
            Text = "Sekant";
            Load += Sekant_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}