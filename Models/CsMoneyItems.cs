using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudParser.Models
{
    public class CsMoneyItems
    {
        [JsonProperty("u")]
        public string U { get; set; }

        [JsonProperty("m")]
        public string M { get; set; }

        [JsonProperty("a")]
        public double A { get; set; }

        [JsonProperty("c", NullValueHandling = NullValueHandling.Ignore)]
        public long? C { get; set; }

        [JsonProperty("g")]
        public G G { get; set; }

        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public long? Z { get; set; }

        [JsonProperty("e", NullValueHandling = NullValueHandling.Ignore)]
        public string E { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public long? W { get; set; }

        [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore)]
        public long? V { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }

        [JsonProperty("j")]
        public string J { get; set; }
    }

    public partial struct G
    {
        public long? Integer;
        public string String;

        public static implicit operator G(long Integer) => new G { Integer = Integer };
        public static implicit operator G(string String) => new G { String = String };
    }
}
