using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class Price
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public decimal PriceDecimal { get; set; }
    }

}