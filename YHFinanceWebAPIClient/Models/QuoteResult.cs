using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace YHFinanceWebAPIClient.Models
{
    class QuoteResult
    {
        [JsonPropertyName("result")]
        public List<Quote> Quotes { get; set; }
    }
}
