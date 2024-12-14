namespace Sayısal_Analiz_Visual_Proje_
{
    partial class LoginRegister
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBoxPassword = new TextBox();
            ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            textBoxUsername = new TextBox();
            tabPage2 = new TabPage();
            label5 = new Label();
            textBox5 = new TextBox();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            ıconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            textBox4 = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBoxPassword);
            tabPage1.Controls.Add(ıconPictureBox1);
            tabPage1.Controls.Add(textBoxUsername);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 393);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Giriş";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(323, 291);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(168, 193);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "Kullanıcı Adı:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(210, 239);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 3;
            label1.Text = "Şifre:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(291, 236);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(164, 27);
            textBoxPassword.TabIndex = 1;
            // 
            // ıconPictureBox1
            // 
            ıconPictureBox1.BackColor = Color.Transparent;
            ıconPictureBox1.ForeColor = Color.Goldenrod;
            ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Lock;
            ıconPictureBox1.IconColor = Color.Goldenrod;
            ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox1.IconSize = 139;
            ıconPictureBox1.Location = new Point(291, 9);
            ıconPictureBox1.Name = "ıconPictureBox1";
            ıconPictureBox1.Size = new Size(164, 139);
            ıconPictureBox1.TabIndex = 1;
            ıconPictureBox1.TabStop = false;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(291, 193);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(164, 27);
            textBoxUsername.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(ıconPictureBox2);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 393);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kayıt";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Highlight;
            label5.Location = new Point(180, 290);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 13;
            label5.Text = "Şifre Doğrulama:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(307, 287);
            textBox5.Name = "textBox5";
            textBox5.PasswordChar = '*';
            textBox5.Size = new Size(164, 27);
            textBox5.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(336, 330);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "Kayıt Ol";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(184, 195);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 10;
            label3.Text = "Kullanıcı Adı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(226, 241);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 9;
            label4.Text = "Şifre:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(307, 238);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(164, 27);
            textBox3.TabIndex = 8;
            // 
            // ıconPictureBox2
            // 
            ıconPictureBox2.BackColor = Color.Transparent;
            ıconPictureBox2.ForeColor = Color.Goldenrod;
            ıconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            ıconPictureBox2.IconColor = Color.Goldenrod;
            ıconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox2.IconSize = 139;
            ıconPictureBox2.Location = new Point(307, 11);
            ıconPictureBox2.Name = "ıconPictureBox2";
            ıconPictureBox2.Size = new Size(269, 139);
            ıconPictureBox2.TabIndex = 7;
            ıconPictureBox2.TabStop = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(307, 195);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(164, 27);
            textBox4.TabIndex = 6;
            // 
            // LoginRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "LoginRegister";
            Text = "LoginRegister";
            Load += LoginRegister_Load;
            KeyDown += LoginRegister_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox textBoxUsername;
        private TabPage tabPage2;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBoxPassword;
        private Button button2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox2;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
    }
}