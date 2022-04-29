using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace YHFinanceWebAPIClient.Models
{
    class QuoteResponse
    {
        [JsonPropertyName("quoteResponse")]
        public QuoteResult QuoteResult { get; set; }
    }
}
