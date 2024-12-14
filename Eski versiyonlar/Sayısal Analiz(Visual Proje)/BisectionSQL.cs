using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sayısal_Analiz_Visual_Proje_
{
    internal class BisectionSQL
    {
        private int _id;
        private string _fonksiyon;
        private int _a, _b;
        private double _sonuc;
        private DateTime _dateTime;

        // Property for 'id'
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // Property for 'fonksiyon'
        public string Fonksiyon
        {
            get { return _fonksiyon; }
            set { _fonksiyon = value; }
        }

        // Property for 'a'
        public int A
        {
            get { return _a; }
            set { _a = value; }
        }

        // Property for 'b'
        public int B
        {
            get { return _b; }
            set { _b = value; }
        }

        // Property for 'sonuc'
        public double Sonuc
        {
            get { return _sonuc; }
            set { _sonuc = value; }
        }

        // Property for 'DateTime'
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        // Constructor
        public BisectionSQL(string fonksiyon, int a, int b, double sonuc, DateTime dateTime)
        {
            _fonksiyon = fonksiyon;
            _a = a;
            _b = b;
            _sonuc = sonuc;
            _dateTime = dateTime;
        }
    }
}
