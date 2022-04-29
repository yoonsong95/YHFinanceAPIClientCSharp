using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace YHFinanceWebAPIClient.Models
{
    class MarketSummary
    {
        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("shortName")]
        public string Name { get; set; }

        [JsonPropertyName("quoteType")]
        public string QuoteType { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

    }
}
