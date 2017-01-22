using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class Creator
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

}