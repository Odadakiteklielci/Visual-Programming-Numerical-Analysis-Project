using System;

namespace Sayısal_Analiz_Visual_Proje_
{
    internal class SekantSQL
    {
        private int _id;
        private string _fonksiyon;
        private double _x0;
        private double _x1;
        private int _iterasyonSayisi;
        private double _sonuc;
        private DateTime _dateTime;
        private string _username;

        // Property for 'id'
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username{
            get { return _username;}
            set { _username = value; }

            }

        // Property for 'fonksiyon'
        public string Fonksiyon
        {
            get { return _fonksiyon; }
            set { _fonksiyon = value; }
        }

        // Property for 'x0' (first approximation)
        public double X0
        {
            get { return _x0; }
            set { _x0 = value; }
        }

        // Property for 'x1' (second approximation)
        public double X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }

        // Property for 'iterasyonSayisi' (iteration count)
        public int IterasyonSayisi
        {
            get { return _iterasyonSayisi; }
            set { _iterasyonSayisi = value; }
        }

        // Property for 'sonuc' (result)
        public double Sonuc
        {
            get { return _sonuc; }
            set { _sonuc = value; }
        }

        // Property for 'DateTime' (the date and time the computation was done)
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        // Constructor
        public SekantSQL(string fonksiyon, double x0, double x1, int iterasyonSayisi, double sonuc, DateTime dateTime, string username)
        {
            _fonksiyon = fonksiyon;
            _x0 = x0;
            _x1 = x1;
            _iterasyonSayisi = iterasyonSayisi;
            _sonuc = sonuc;
            _dateTime = dateTime;
            _username = username;
        }
    }
}
