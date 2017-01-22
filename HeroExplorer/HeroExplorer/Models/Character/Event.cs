using Newtonsoft.Json;

namespace HeroExplorer.Models.Character
{

    public class Event
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}