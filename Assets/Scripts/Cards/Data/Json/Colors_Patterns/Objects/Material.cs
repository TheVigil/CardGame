using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data.Json.Colors_Patterns.Objects
{
    public class Material
    {
        [JsonProperty(PropertyName = "term")]
        public string _term { get; set; }

        [JsonProperty(PropertyName = "related")]
        public List<MatRelation> _related { get; set; }
    }
}