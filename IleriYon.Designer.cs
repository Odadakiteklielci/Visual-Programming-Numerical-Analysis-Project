namespace Sayısal_Analiz_Visual_Proje_
{
    partial class IleriYon
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
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(389, 191);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Tamam";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(289, 52);
            label2.Name = "label2";
            label2.Size = new Size(270, 106);
            label2.TabIndex = 5;
            label2.Text = "P(      )";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(9, 14);
            label1.Name = "label1";
            label1.Size = new Size(848, 31);
            label1.TabIndex = 4;
            label1.Text = "Yaklaşık Polinom Bulundu. Bu polinomda hesaplamak istediğiniz x değerini giriniz:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 28.2F);
            textBox1.Location = new Point(380, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 70);
            textBox1.TabIndex = 8;
            // 
            // IleriYon
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 239);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "IleriYon";
            Text = "IleriYon";
            Load += IleriYon_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
    }
}