using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{
    public class Date
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("date")]
        public string DateString { get; set; }
    }

}