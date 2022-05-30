using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class Literatur
    {
        [JsonProperty(PropertyName = "typ")]
        public string _type { get; set; }

        [JsonProperty(PropertyName = "urheber")]
        public string _author { get; set; }

        [JsonProperty(PropertyName = "titel")]
        public string _title { get; set; }

        [JsonProperty(PropertyName = "zusatz")]
        public string _addition { get; set; }

        [JsonProperty(PropertyName = "erscheinungsort")]
        public string _publicationLoc { get; set; }

        [JsonProperty(PropertyName = "erscheinungsjahr")]
        public string _publicationYear { get; set; }

        [JsonProperty(PropertyName = "abbildungen")]
        public string _abstract { get; set; }

        [JsonProperty(PropertyName = "anzabbildungen")]
        public string _anzAbs { get; set; }
    }
}