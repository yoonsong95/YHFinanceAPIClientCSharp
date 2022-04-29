using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using YHFinanceWebAPIClient.Models;
using Newtonsoft.Json.Linq;


namespace YHFinanceWebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiKey = "replace string with API key";

        // newiyo5137@wowcg.com - YH API

        private static async Task<QuoteResponse> ProcessQuotes(string symbols)
        {
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            var url = $"https://yfapi.net/v6/finance/quote?region=US&lang=en&symbols={symbols}";
            var streamTask = client.GetStreamAsync(url);
            var quoteResponse = await JsonSerializer.DeserializeAsync<QuoteResponse>(await streamTask);
            return quoteResponse;
        }

        private static async Task<FinanceInsight> ProcessFinanceInsight(string symbol)
        {
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            var url = $"https://yfapi.net/ws/insights/v1/finance/insights/?symbol={symbol}";
            var streamTask = await client.GetStringAsync(url);
            var financeInsightResponse = JObject.Parse(streamTask);
            var financeInsight = new FinanceInsight
            {
                Company = financeInsightResponse["finance"]["result"]["companySnapshot"]["company"].ToObject<Company>(),
                Recommendation = financeInsightResponse["finance"]["result"]["instrumentInfo"]["recommendation"].ToObject<Recommendation>()
            };
            return financeInsight;
        }


        public static async Task Main(string[] args)
        {
            // Quotes
            //var quoteResponse = await ProcessQuotes("MSFT,NVDA,F");
            //var quotes = quoteResponse.QuoteResult.Quotes;
            //foreach (var quote in quotes)
            //{
            //    Console.WriteLine("Company Name: " + quote.CompanyName);
            //    Console.WriteLine("Ticker: " + quote.Symbol);
            //    Console.WriteLine("Currency: " + quote.Currency);
            //    Console.WriteLine("Price: " + quote.Price);
            //    Console.WriteLine("Fifty Day Average Price: " + quote.FiftyDayAveragePrice);
            //    Console.WriteLine("Volume: " + quote.Volume);
            //    Console.WriteLine();
            //}
            //Console.WriteLine();


            // Note: Cannot make another API Call right away

            // Finance Insights
            var symbol = "F";
            var financeResult = await ProcessFinanceInsight(symbol);

            Console.WriteLine($"Finance Insights: {symbol}");
            Console.WriteLine("\nCompany");
            Console.WriteLine("Dividends: " + Math.Round(financeResult.Company.Dividends, 4));
            Console.WriteLine("Hiring: " + Math.Round(financeResult.Company.Hiring, 4));
            Console.WriteLine("Innovativeness: " + Math.Round(financeResult.Company.Innovativeness, 4));
            Console.WriteLine("\nRecommendation");
            Console.WriteLine("Provider: " + financeResult.Recommendation.Provider);
            Console.WriteLine("Rating: " + financeResult.Recommendation.Rating);
            Console.WriteLine("Target Price: " + financeResult.Recommendation.TargetPrice);
        }
    }
}
