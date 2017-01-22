using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeroExplorer.Models.Character
{

    public class SeriesList
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<Series> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

}