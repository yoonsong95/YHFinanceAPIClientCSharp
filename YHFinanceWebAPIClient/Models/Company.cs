using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace YHFinanceWebAPIClient.Models
{
    class Company
    {
        [JsonPropertyName("dividends")]
        public double Dividends { get; set; }
    
        [JsonPropertyName("hiring")]
        public double Hiring { get; set; }

        [JsonPropertyName("innovativeness")]
        public double Innovativeness { get; set; }
    }
}
