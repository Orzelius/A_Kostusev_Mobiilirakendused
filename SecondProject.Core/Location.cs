using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondProject.Core {
    public partial class Location {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public long Woeid { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }
    }
}
