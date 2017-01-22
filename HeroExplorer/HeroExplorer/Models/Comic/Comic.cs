using System.Collections.Generic;
using HeroExplorer.Models.Character;
using Newtonsoft.Json;

namespace HeroExplorer.Models.Comic
{

    public class Comic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("digitalId")]
        public int DigitalId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("issueNumber")]
        public double IssueNumber { get; set; }

        [JsonProperty("variantDescription")]
        public string VariantDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("diamondCode")]
        public string DiamondCode { get; set; }

        [JsonProperty("ean")]
        public string Ean { get; set; }

        [JsonProperty("issn")]
        public string Issn { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("textObjects")]
        public List<TextObject> TextObjects { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("variants")]
        public List<object> Variants { get; set; }

        [JsonProperty("collections")]
        public List<object> Collections { get; set; }

        [JsonProperty("collectedIssues")]
        public List<object> CollectedIssues { get; set; }

        [JsonProperty("dates")]
        public List<Date> Dates { get; set; }

        [JsonProperty("prices")]
        public List<Price> Prices { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("creators")]
        public CreatorsList Creators { get; set; }

        [JsonProperty("characters")]
        public CharactersList Characters { get; set; }

        [JsonProperty("stories")]
        public StoriesList Stories { get; set; }

        [JsonProperty("events")]
        public EventsList Events { get; set; }
    }

}