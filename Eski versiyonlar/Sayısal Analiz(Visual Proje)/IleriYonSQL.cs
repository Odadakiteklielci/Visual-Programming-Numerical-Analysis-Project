internal class IleriYonSQL
{
    private int _id;
    private string _noktalar;
    private double _x;
    private double _sonuc;
    private DateTime _dateTime;

    // Constructor
    public IleriYonSQL(string noktalar, double interpolasyonNoktasi, double sonuc, DateTime dateTime)
    {
        _noktalar = noktalar;
        _x = interpolasyonNoktasi;
        _sonuc = sonuc;
        _dateTime = dateTime;
    }

    // Property'ler
    public int Id { get => _id; set => _id = value; }
    public string Noktalar { get => _noktalar; set => _noktalar = value; }
    public double InterpolasyonNoktasi { get => _x; set => _x = value; }
    public double Sonuc { get => _sonuc; set => _sonuc = value; }
    public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
}