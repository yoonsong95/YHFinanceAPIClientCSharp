using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace YHFinanceWebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        private static async Task<QuoteResponse> ProcessQuotes(string symbols)
        {
            string apiKey = "Replace this string with API Key";
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            var url = $"https://yfapi.net/v6/finance/quote?region=US&lang=en&symbols={symbols}";
            var streamTask = client.GetStreamAsync(url);
            var quoteResponse = await JsonSerializer.DeserializeAsync<QuoteResponse>(await streamTask);
            return quoteResponse;
        }

        public static async Task Main(string[] args)
        {
            var quoteResponse = await ProcessQuotes("MSFT,NVDA,F");
            var quotes = quoteResponse.QuoteResult.Quotes;
            foreach (var quote in quotes)
            {
                Console.WriteLine(quote.CompanyName);
                Console.WriteLine(quote.Symbol);
                Console.WriteLine(quote.Currency);
                Console.WriteLine(quote.Price);
                Console.WriteLine(quote.FiftyDayAveragePrice);
                Console.WriteLine(quote.Volume);
                Console.WriteLine();
            }
        }
    }
}
