using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{
    public class ComicDataWrapper
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty("attributionHTML")]
        public string AttributionHtml { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("data")]
        public ComicDataContainer Data { get; set; }
    }
}