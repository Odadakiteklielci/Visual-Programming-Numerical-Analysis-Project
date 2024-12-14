using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sayısal_Analiz_Visual_Proje_
{
    internal class RegulaSQL
    {
        // Class fields
        private int _id;
        private string _fonksiyon;
        private double _a;
        private double _b;
        private double _sonuc;
        private DateTime _dateTime;

        // Constructor
        public RegulaSQL( string fonksiyon, double a, double b, double sonuc, DateTime dateTime)
        {
            
            _fonksiyon = fonksiyon;
            _a = a;
            _b = b;
            _sonuc = sonuc;
            _dateTime = dateTime;
        }

        // Getter and Setter for _id
        

        // Getter and Setter for _fonksiyon
        public string Fonksiyon
        {
            get { return _fonksiyon; }
            set { _fonksiyon = value; }
        }

        // Getter and Setter for _a
        public double A
        {
            get { return _a; }
            set { _a = value; }
        }

        // Getter and Setter for _b
        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        // Getter and Setter for _sonuc
        public double Sonuc
        {
            get { return _sonuc; }
            set { _sonuc = value; }
        }

        // Getter and Setter for _dateTime
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        // Example method for displaying result
        
    }
}
