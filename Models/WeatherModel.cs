using Newtonsoft.Json;
namespace AspNetMVC.Models
{
    public class WeatherModel
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }

        public string WeatherType { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
    }
}