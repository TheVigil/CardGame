using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class Submaster
    {
        [JsonProperty(PropertyName = "guid")]
        public string _subGuid { get; set; }

        [JsonProperty(PropertyName = "pfad")]
        public string _subPath { get; set; }
    }
}