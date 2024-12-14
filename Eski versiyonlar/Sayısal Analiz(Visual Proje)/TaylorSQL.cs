using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sayısal_Analiz_Visual_Proje_
{
    internal class TaylorSQL
    {
        public int id;
        public string fonksiyon;
        public double x0;
        public double x;
        public int iterasyonSayisi;
        public double sonuc;
        public double gercekDeger;
        public double hata;
        public DateTime DateTime;

        public TaylorSQL( string fonksiyon, double x0, double x, int iterasyonSayisi, double sonuc, double gercekDeger, double hata, DateTime dateTime)
        {
            
            this.fonksiyon = fonksiyon;
            this.x0 = x0;
            this.x = x;
            this.iterasyonSayisi = iterasyonSayisi;
            this.sonuc = sonuc;
            this.gercekDeger = gercekDeger;
            this.hata = hata;
            DateTime = dateTime;
        }
    }
}
