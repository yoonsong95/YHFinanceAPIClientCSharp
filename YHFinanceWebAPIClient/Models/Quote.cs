using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YHFinanceWebAPIClient.Models
{
    class Quote
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("shortName")]
        public string CompanyName { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("regularMarketPrice")]
        public double Price { get; set; }

        [JsonProperty("fiftyDayAverage")]
        public double FiftyDayAveragePrice { get; set; }

        [JsonProperty("regularMarketVolume")]
        public int Volume { get; set; }
    }
}
