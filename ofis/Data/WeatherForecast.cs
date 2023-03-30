using SQLite;
namespace ofis.Data;
public class WeatherForecast
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Unvan { get; set; }
    public string Hatirlatma { get; set; }
    public bool Bordro { get; set; }
    public bool Faturalar { get; set; }
    public bool Kdv { get; set; }
    public bool Muhtasar { get; set; }
    public bool Odemeler { get; set; }
    public bool Gecici { get; set; }
    public bool Yillik { get; set; }
    public bool HatirlatmaOlacakmi { get; set; }
    public bool BordroOlacakmi { get; set; }
    public bool FaturalarOlacakmi { get; set; }
    public bool KdvOlacakmi { get; set; }
    public bool MuhtasarOlacakmi { get; set; }
    public bool OdemelerOlacakmi { get; set; }
    public bool GeciciOlacakmi { get; set; }
    public bool YillikOlacakmi { get; set; }

}