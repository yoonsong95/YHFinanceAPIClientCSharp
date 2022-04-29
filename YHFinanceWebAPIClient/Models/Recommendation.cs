using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace YHFinanceWebAPIClient.Models
{
    class Recommendation
    {
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        [JsonPropertyName("rating")]
        public string Rating { get; set; }

        [JsonPropertyName("targetPrice")]
        public double TargetPrice { get; set; }
    }
}
