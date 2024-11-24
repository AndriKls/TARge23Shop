namespace ShopTARge23.Models.OpenWeathers
{
    public class OpenWeathersViewModel
    {
        public string City { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public string Conditions { get; set; }
        public string Icon { get; set; }
    }
}
