using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data.Json.Colors_Patterns.Objects
{
    public class OutputParameter
    {
        [JsonProperty(PropertyName = "guid")]
        public string _guid { get; set; }

        [JsonProperty(PropertyName = "eingangsjahr")]
        public string _entryYear { get; set; }

        [JsonProperty(PropertyName = "inventarnummer")]
        public string _invNum { get; set; }

        [JsonProperty(PropertyName = "bereich")]
        public string _domain { get; set; }

        [JsonProperty(PropertyName = "sammlung")]
        public string _collection { get; set; }

        [JsonProperty(PropertyName = "person")]
        public List<Person> _artist { get; set; }

        [JsonProperty(PropertyName = "titel")]
        public string _title { get; set; }

        [JsonProperty(PropertyName = "titelen")]
        public string _titleen { get; set; }

        [JsonProperty(PropertyName = "masse")]
        public List<Dimensions> _dimensions { get; set; }

        [JsonProperty(PropertyName = "entstehungszeit")]
        public string _creationTime { get; set; }

        [JsonProperty(PropertyName = "material")]
        public List<Material> _materials { get; set; }

        [JsonProperty(PropertyName = "technik")]
        public List<Technique> _techs { get; set; }

        [JsonProperty(PropertyName = "creditline")]
        public string _credit { get; set; }

        [JsonProperty(PropertyName = "eingangstext")]
        public string _entryText { get; set; }

        [JsonProperty(PropertyName = "textdigitalerkatalog")]
        public string _digiKatalog { get; set; }

        [JsonProperty(PropertyName = "urheberrechtkuenstler")]
        public string _copyrightArtis { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string _status { get; set; }

        [JsonProperty(PropertyName = "objektbezeichnung")]
        public string _objDesc { get; set; }

        [JsonProperty(PropertyName = "literatur")]
        public List<Literatur> _literatur { get; set; }

        [JsonProperty(PropertyName = "submaster")]
        public List<Submaster> _submasters { get; set; }
    }
}