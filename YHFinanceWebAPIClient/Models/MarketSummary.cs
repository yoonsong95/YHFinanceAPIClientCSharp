using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YHFinanceWebAPIClient.Models
{
    class MarketSummary
    {
        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("shortName")]
        public string Name { get; set; }

        [JsonProperty("quoteType")]
        public string QuoteType { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

    }
}
