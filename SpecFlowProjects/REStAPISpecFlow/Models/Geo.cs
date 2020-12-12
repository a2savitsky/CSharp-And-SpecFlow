using Newtonsoft.Json;

namespace REStAPISpecFlow.Models
{
    public class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
}