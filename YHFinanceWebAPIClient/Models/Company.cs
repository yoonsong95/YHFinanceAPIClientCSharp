using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YHFinanceWebAPIClient.Models
{
    class Company
    {
        [JsonProperty("dividends")]
        public double Dividends { get; set; }
    
        [JsonProperty("hiring")]
        public double Hiring { get; set; }

        [JsonProperty("innovativeness")]
        public double Innovativeness { get; set; }
    }
}
