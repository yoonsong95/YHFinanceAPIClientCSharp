using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YHFinanceWebAPIClient.Models
{
    class Recommendation
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("targetPrice")]
        public double TargetPrice { get; set; }
    }
}
