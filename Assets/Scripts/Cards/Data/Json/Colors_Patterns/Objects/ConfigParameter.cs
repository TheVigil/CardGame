using System;
using Newtonsoft.Json;

namespace Data.Json.Colors_Patterns.Objects
{
    public class ConfigParameter
    {
        [JsonProperty(PropertyName = "guids")]
        public List<string> _guids { get; set; }

        [JsonProperty(PropertyName = "img_save_path")]
        public string _savePath { get; set; }
    }
}