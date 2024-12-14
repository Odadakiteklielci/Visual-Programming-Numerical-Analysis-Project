namespace Sayısal_Analiz_Visual_Proje_
{
    partial class anaMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            baslik = new Label();
            analizButon = new FontAwesome.Sharp.IconButton();
            gecmisButon = new FontAwesome.Sharp.IconButton();
            cikisButon = new FontAwesome.Sharp.IconButton();
            hakkindabuton = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // baslik
            // 
            baslik.Anchor = AnchorStyles.Top;
            baslik.AutoSize = true;
            baslik.Font = new Font("Lucida Sans Unicode", 36F, FontStyle.Regular, GraphicsUnit.Point, 162);
            baslik.ForeColor = SystemColors.GradientActiveCaption;
            baslik.Location = new Point(116, 20);
            baslik.Name = "baslik";
            baslik.Size = new Size(822, 73);
            baslik.TabIndex = 0;
            baslik.Text = "SAYISAL ANALİZ PROGRAMI";
            baslik.Click += baslik_Click;
            // 
            // analizButon
            // 
            analizButon.Anchor = AnchorStyles.None;
            analizButon.AutoSize = true;
            analizButon.BackColor = Color.Thistle;
            analizButon.FlatStyle = FlatStyle.Popup;
            analizButon.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            analizButon.ForeColor = Color.Black;
            analizButon.IconChar = FontAwesome.Sharp.IconChar.ChartArea;
            analizButon.IconColor = Color.Black;
            analizButon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            analizButon.IconSize = 90;
            analizButon.Location = new Point(313, 127);
            analizButon.Name = "analizButon";
            analizButon.Size = new Size(205, 176);
            analizButon.TabIndex = 1;
            analizButon.Text = "Analiz Yap";
            analizButon.TextAlign = ContentAlignment.BottomCenter;
            analizButon.UseVisualStyleBackColor = false;
            analizButon.Click += analizButon_Click;
            // 
            // gecmisButon
            // 
            gecmisButon.Anchor = AnchorStyles.None;
            gecmisButon.AutoSize = true;
            gecmisButon.BackColor = Color.Yellow;
            gecmisButon.FlatStyle = FlatStyle.Popup;
            gecmisButon.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            gecmisButon.ForeColor = Color.Black;
            gecmisButon.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            gecmisButon.IconColor = Color.Black;
            gecmisButon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            gecmisButon.IconSize = 90;
            gecmisButon.Location = new Point(525, 127);
            gecmisButon.Name = "gecmisButon";
            gecmisButon.Size = new Size(202, 176);
            gecmisButon.TabIndex = 2;
            gecmisButon.Text = "Geçmiş";
            gecmisButon.TextAlign = ContentAlignment.BottomCenter;
            gecmisButon.UseVisualStyleBackColor = false;
            gecmisButon.Click += gecmisButon_Click;
            // 
            // cikisButon
            // 
            cikisButon.Anchor = AnchorStyles.None;
            cikisButon.AutoSize = true;
            cikisButon.BackColor = Color.Tomato;
            cikisButon.FlatStyle = FlatStyle.Popup;
            cikisButon.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            cikisButon.ForeColor = Color.Black;
            cikisButon.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            cikisButon.IconColor = Color.Black;
            cikisButon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            cikisButon.IconSize = 90;
            cikisButon.Location = new Point(525, 309);
            cikisButon.Name = "cikisButon";
            cikisButon.Size = new Size(202, 176);
            cikisButon.TabIndex = 4;
            cikisButon.Text = "Çıkış";
            cikisButon.TextAlign = ContentAlignment.BottomCenter;
            cikisButon.UseVisualStyleBackColor = false;
            cikisButon.Click += cikisButon_Click;
            // 
            // hakkindabuton
            // 
            hakkindabuton.Anchor = AnchorStyles.None;
            hakkindabuton.AutoSize = true;
            hakkindabuton.BackColor = Color.FromArgb(0, 192, 0);
            hakkindabuton.FlatStyle = FlatStyle.Popup;
            hakkindabuton.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            hakkindabuton.ForeColor = Color.Black;
            hakkindabuton.IconChar = FontAwesome.Sharp.IconChar.Info;
            hakkindabuton.IconColor = Color.Black;
            hakkindabuton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            hakkindabuton.IconSize = 90;
            hakkindabuton.Location = new Point(314, 309);
            hakkindabuton.Name = "hakkindabuton";
            hakkindabuton.Size = new Size(205, 176);
            hakkindabuton.TabIndex = 3;
            hakkindabuton.Text = "Hakkında";
            hakkindabuton.TextAlign = ContentAlignment.BottomCenter;
            hakkindabuton.UseVisualStyleBackColor = false;
            hakkindabuton.Click += hakkindabuton_Click;
            // 
            // anaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1045, 551);
            ControlBox = false;
            Controls.Add(cikisButon);
            Controls.Add(hakkindabuton);
            Controls.Add(gecmisButon);
            Controls.Add(analizButon);
            Controls.Add(baslik);
            ForeColor = Color.Cornsilk;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "anaMenu";
            Text = "Sayısal Analiz Programı";
            Load += anaMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label baslik;
        private FontAwesome.Sharp.IconButton analizButon;
        private FontAwesome.Sharp.IconButton gecmisButon;
        private FontAwesome.Sharp.IconButton cikisButon;
        private FontAwesome.Sharp.IconButton hakkindabuton;
    }
}
