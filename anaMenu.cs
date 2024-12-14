using System.Data.SQLite;
using System.Diagnostics;

namespace Sayısal_Analiz_Visual_Proje_
{
    public partial class anaMenu : Form
    {
        private UserSQL userSQL;

        public anaMenu()
        {
            InitializeComponent();
        }
        public anaMenu(UserSQL user)
        {
            InitializeComponent();
            userSQL = user; // Gelen UserSQL nesnesini al
        }
        private void baslik_Click(object sender, EventArgs e)
        {

        }

        private void cikisButon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hakkindabuton_Click(object sender, EventArgs e)
        {
            Hakkında hakkında = new Hakkında();
            hakkında.Show();
        }

        private void analizButon_Click(object sender, EventArgs e)
        {
            Islemler islemler = new Islemler(0,userSQL);
            islemler.Show();
        }

        private void anaMenu_Load(object sender, EventArgs e)
        {

        }

        private void gecmisButon_Click(object sender, EventArgs e)
        {
            Islemler islemler = new Islemler(1,userSQL);
            islemler.Show();
        }
    }
}
