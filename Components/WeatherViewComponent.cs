using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AspNetMVC.Models;

namespace AspNetMVC.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            using (var httpClient = new HttpClient())
            {
                var apiKey = "9f50a9e5b99b52ca6607e6b3e4cbc562";
                var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Mykolaiv&appid={apiKey}&units=metric";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic jsonObject = JsonConvert.DeserializeObject(content);

                    WeatherModel weather = new WeatherModel
                    {
                        City = jsonObject.name,
                        Temperature = jsonObject.main.temp,
                        Pressure = jsonObject.main.pressure,
                        TempMin = jsonObject.main.temp_min,
                        TempMax = jsonObject.main.temp_max,
                        WeatherType = jsonObject.weather[0].main,
                        Humidity = jsonObject.main.humidity,
                        WindSpeed = jsonObject.wind.speed,


                    };
                    return View("/Views/Product/WeatherView.cshtml", weather);
                }
            }
            return Content("Помилка отримання погоди");
        }

    }
}