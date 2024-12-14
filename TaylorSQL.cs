using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sayısal_Analiz_Visual_Proje_
{
    internal class TaylorSQL
    {
        private string username;

        public int Id { get; set; }          // id'yi daha temiz bir şekilde property olarak tanımladım.
        public string Fonksiyon { get; set; }  // fonksiyon property olarak tanımlandı.
        private string Username { get => username; set => username = value; }  // username private olarak tanımlandı.
        public double X0 { get; set; }        // x0 property olarak tanımlandı.
        public double X { get; set; }         // x property olarak tanımlandı.
        public int IterasyonSayisi { get; set; }  // iterasyon sayısı property olarak tanımlandı.
        public double Sonuc { get; set; }     // sonuç property olarak tanımlandı.
        public double GercekDeger { get; set; }  // gerçek değer property olarak tanımlandı.
        public double Hata { get; set; }      // hata property olarak tanımlandı.
        public DateTime DateTime { get; set; }  // DateTime property olarak tanımlandı.

        public TaylorSQL(string fonksiyon, double x0, double x, int iterasyonSayisi, double sonuc, double gercekDeger, double hata, DateTime dateTime, string username)
        {
            Fonksiyon = fonksiyon;
            X0 = x0;
            X = x;
            IterasyonSayisi = iterasyonSayisi;
            Sonuc = sonuc;
            GercekDeger = gercekDeger;
            Hata = hata;
            DateTime = dateTime;
            Username = username;
        }
    }
}
