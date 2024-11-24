using Nancy.Json;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge23.ApplicationServices.Services
{
    public class OpenWeathersServices : IOpenWeathersServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string apiKey = "fe4e885cc104b4114c1fa726c63b1f18";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={apiKey}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(apiUrl);

                OpenWeatherRootDto result = new JavaScriptSerializer().Deserialize<OpenWeatherRootDto>(json);

                dto.City = result.name;
                dto.Temp = result.main.temp;
                dto.FeelsLike = result.main.feels_like;
                dto.Humidity = result.main.humidity;
                dto.Pressure = result.main.pressure;
                dto.WindSpeed = result.wind.speed;
                dto.Conditions = result.weather[0].description;
                dto.Icon = result.weather[0].icon;
            }

            return dto;
        }
    }
}
