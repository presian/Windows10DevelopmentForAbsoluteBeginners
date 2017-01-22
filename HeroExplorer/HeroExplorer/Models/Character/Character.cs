using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeroExplorer.Models.Character
{

    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("comics")]
        public ComicsList Comics { get; set; }

        [JsonProperty("series")]
        public SeriesList Series { get; set; }

        [JsonProperty("stories")]
        public StoriesList Stories { get; set; }

        [JsonProperty("events")]
        public EventsList Events { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }
    }

}