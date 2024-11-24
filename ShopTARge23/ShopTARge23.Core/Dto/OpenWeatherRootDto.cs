using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge23.Core.Dto
{
    public class OpenWeatherRootDto
    {
        [JsonPropertyName("coord")]
        public Coord coord { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> weather { get; set; }

        [JsonPropertyName("base")]
        public string @base { get; set; }

        [JsonPropertyName("main")]
        public Main main { get; set; }

        [JsonPropertyName("visibility")]
        public int visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds clouds { get; set; }

        [JsonPropertyName("dt")]
        public int dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys sys { get; set; }

        [JsonPropertyName("timezone")]
        public int timezone { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("cod")]
        public int cod { get; set; }
    }
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int all { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public double lon { get; set; }

        [JsonPropertyName("lat")]
        public double lat { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double feels_like { get; set; }

        [JsonPropertyName("temp_min")]
        public double temp_min { get; set; }

        [JsonPropertyName("temp_max")]
        public double temp_max { get; set; }

        [JsonPropertyName("pressure")]
        public int pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int sea_level { get; set; }

        [JsonPropertyName("grnd_level")]
        public int grnd_level { get; set; }
    }
    public class Sys
    {
        [JsonPropertyName("type")]
        public int type { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonPropertyName("sunrise")]
        public int sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int sunset { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("main")]
        public string main { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("icon")]
        public string icon { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double speed { get; set; }

        [JsonPropertyName("deg")]
        public int deg { get; set; }
    }
}

