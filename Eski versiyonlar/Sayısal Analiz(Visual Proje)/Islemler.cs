using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sayısal_Analiz_Visual_Proje_
{
    public partial class Islemler : Form
    {
        private int sebep;
        public Islemler(int sebep)
        {
            InitializeComponent();
            this.sebep = sebep;
        }



        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                comboBox1.Visible = true;
                comboBox1.SelectedIndex = 0;
                radioButton4.Location = new System.Drawing.Point(42, 194);
                radioButton3.Location = new System.Drawing.Point(42, 224);
            }
            else
            {
                comboBox1.Visible = false;
                radioButton4.Location = new System.Drawing.Point(42, 166);
                radioButton3.Location = new System.Drawing.Point(42, 196);

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox2.Visible = true;
                comboBox2.SelectedIndex = 0;


            }
            else
            {
                comboBox2.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (sebep == 0)
                {
                    Taylor taylor = new Taylor();
                    taylor.Show();
                }
                if (sebep == 1)
                {
                    TaylorTablo taylorTablo = new TaylorTablo();
                    taylorTablo.Show();
                }
            }
            if (radioButton5.Checked)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (sebep == 0)
                        {
                            Bisection bis = new Bisection();
                            bis.Show();
                            break;
                        }
                        BisectionTablo bisectionTablo = new BisectionTablo();
                        bisectionTablo.Show();

                        break;
                    case 1:
                        if (sebep == 0)
                        {
                            Sekant sek = new Sekant();
                            sek.Show();
                            break;
                        }
                        SekantTablo sekantTablo = new SekantTablo();
                        sekantTablo.Show();
                        break;
                    case 2:
                        if (sebep == 0)
                        {
                            Regula regu = new Regula();
                            regu.Show();
                            break;
                        }
                        RegulaTablo regulaTablo = new RegulaTablo();
                        regulaTablo.Show();
                        break;

                }
            }
            if (radioButton4.Checked)
            {if (sebep == 0)
                {
                    NoktaSec lagrange = new NoktaSec(4); ;
                    lagrange.Show();
                }
            if (sebep == 1) {
                    LagrangeTablo lagrangeTablo = new LagrangeTablo();
                    lagrangeTablo.Show();
                }
                
            }
            if (radioButton3.Checked)
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        if (sebep == 0)
                        {
                            NoktaSec ileriYon = new NoktaSec(3);
                            ileriYon.Show();
                            break;
                        }
                        IleriYonTablo ileriYonTablo = new IleriYonTablo();
                        ileriYonTablo.Show();
                        break;
                    case 1:
                        if (sebep == 0)
                        {
                            NoktaSec geriYon = new NoktaSec(3.1);
                            geriYon.Show();
                            break;
                        }
                        GeriYonTablo geriYonTablo = new GeriYonTablo();
                        geriYonTablo.Show();
                        break;

                }
            }
        }

        private void Islemler_Load(object sender, EventArgs e)
        {

        }
    }
}
