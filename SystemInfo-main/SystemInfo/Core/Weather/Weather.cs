using Newtonsoft.Json;

namespace SystemInfo.Core.Weather
{
    public sealed class Weather
    {
        public static async Task<Root> Get(string name)
        {
            string json = await new HttpClient().GetStringAsync($"http://api.weatherapi.com/v1/current.json?key=eab2ce4dd8c24c09b0c174907222505&q={name}&aqi=no");
            return JsonConvert.DeserializeObject<Root>(json);
        }
    }

    public class Condition
    {
    }

    public class Current
    {
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public Condition condition { get; set; }
        public double uv { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public string localtime { get; set; }
    }

    public class Root
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }
}
