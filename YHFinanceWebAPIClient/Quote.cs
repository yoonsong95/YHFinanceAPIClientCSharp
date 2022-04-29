using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace YHFinanceWebAPIClient
{
    class Quote
    {
        [JsonPropertyName("shortName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public double Price { get; set; }

        [JsonPropertyName("fiftyDayAverage")]
        public double FiftyDayAveragePrice { get; set; }

        [JsonPropertyName("regularMarketVolume")]
        public int Volume { get; set; }
    }
}
