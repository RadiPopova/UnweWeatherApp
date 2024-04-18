using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnweWeatherApp
{
    public partial class WeatherData
    {

        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; }
        public long visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public long dt { get; set; }
        public Sys sys { get; set; }
        public long timezone { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public long cod { get; set; }
    }
    public partial class ForecastData
    {
       
        public long cod { get; set; }
        public long message { get; set; }
        public long cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }

    public partial class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public partial class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public long pressure { get; set; }
        public long humidity { get; set; }
        public long sea_level { get; set; }
        public long grnd_level { get; set; }
    }


    public partial class Sys
    {
        public long type { get; set; }
        public long id { get; set; }
        public string country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }

    public partial class Weather
    {
        public long id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public partial class Wind
    {
        public double speed { get; set; }
        public long deg { get; set; }
        public double gust { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public partial class City
    {
        public long id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public long population { get; set; }
        public long timezone { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }

    public partial class Clouds
    {
        public long all { get; set; }
    }


    public partial class List
    {
        public long dt { get; set; }
        public Main main { get; set; }
        public Weather[] weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public long visibility { get; set; }
        public double pop { get; set; }
        public Sys sys { get; set; }
        public DateTimeOffset dt_txt { get; set; }
        public Rain rain { get; set; }
    }


    public partial class Rain
    {
        [JsonProperty("3h")]
        public double _3h { get; set; }
    }

}

       

