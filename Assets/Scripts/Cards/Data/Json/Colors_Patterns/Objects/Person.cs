using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class Person
    {
        [JsonProperty(PropertyName = "typ")]
        public string _type { get; set; }

        [JsonProperty(PropertyName = "anzeigename")]
        public string _fullname { get; set; }

        [JsonProperty(PropertyName = "nachname")]
        public string _sirname { get; set; }

        [JsonProperty(PropertyName = "vorname")]
        public string _forename { get; set; }

        [JsonProperty(PropertyName = "geburtsdatum")]
        public string _birthdate { get; set; }

        [JsonProperty(PropertyName = "geburtsort")]
        public string _birthplace { get; set; }

        [JsonProperty(PropertyName = "sterbedatum")]
        public string _deathdate { get; set; }

        [JsonProperty(PropertyName = "sterbeort")]
        public string _deathplace { get; set; }

        [JsonProperty(PropertyName = "notiz")]
        public string _notice { get; set; }
    }
}