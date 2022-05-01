using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using YHFinanceWebAPIClient.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace YHFinanceWebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiKey = "replace string with API key";
        private static readonly string baseUrl = "https://yfapi.net";

        // newiyo5137@wowcg.com - YH API

        private static async Task<QuoteResponse> ProcessQuotes(string symbols)
        {
            var url = $"{baseUrl}/v6/finance/quote?region=US&lang=en&symbols={symbols}";
            var streamTask = await client.GetStreamAsync(url);
            var quoteResponse = await JsonSerializer.DeserializeAsync<QuoteResponse>(streamTask);
            return quoteResponse;
        }

        private static async Task<FinanceInsight> ProcessFinanceInsight(string symbol)
        {
            var url = $"{baseUrl}/ws/insights/v1/finance/insights/?symbol={symbol}";
            var stringTask = await client.GetStringAsync(url);
            var financeInsightResponse = JObject.Parse(stringTask);
            var financeInsight = new FinanceInsight
            {
                Company = financeInsightResponse["finance"]["result"]["companySnapshot"]["company"].ToObject<Company>(),
                Recommendation = financeInsightResponse["finance"]["result"]["instrumentInfo"]["recommendation"].ToObject<Recommendation>()
            };
            return financeInsight;
        }

        private static async Task<List<MarketSummary>> ProcessMarketSummary()
        {
            var url = $"{baseUrl}/v6/finance/quote/marketSummary";
            var stringTask = await client.GetStringAsync(url);
            var marketSummaryResponse = JObject.Parse(stringTask);           
            var marketSummaryResult = marketSummaryResponse["marketSummaryResponse"]["result"].Children().AsEnumerable();
            var marketSummaryList = new List<MarketSummary>();
            foreach (var marketSummary in marketSummaryResult)
            {
                marketSummaryList.Add(marketSummary.ToObject<MarketSummary>());
            }
            return marketSummaryList;
        }


        public static async Task Main(string[] args)
        {
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);


            //Quotes
            var symbols = "MSFT,NVDA,AMD,UBER,F";
            var quoteResponse = await ProcessQuotes(symbols);
            var quotes = quoteResponse.QuoteResult.Quotes;
            foreach (var quote in quotes)
            {
                Console.WriteLine("Company Name: " + quote.CompanyName);
                Console.WriteLine("Ticker: " + quote.Symbol);
                Console.WriteLine("Currency: " + quote.Currency);
                Console.WriteLine("Price: " + quote.Price);
                Console.WriteLine("Fifty Day Average Price: " + quote.FiftyDayAveragePrice);
                Console.WriteLine("Volume: " + quote.Volume);
                Console.WriteLine();
            }
            Console.WriteLine();


            // Finance Insights
            var symbol = "MSFT";
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
            Console.WriteLine();


            // Market Summary
            var marketSummaryList = await ProcessMarketSummary();
            Console.WriteLine("\nMarket Summary");
            foreach (var marketSummary in marketSummaryList)
            {
                Console.WriteLine("Exchange: " + marketSummary.Exchange);
                Console.WriteLine("Name: " + marketSummary.Name);
                Console.WriteLine("Quote Type: " + marketSummary.QuoteType);
                Console.WriteLine("Region: " + marketSummary.Region);
                Console.WriteLine();
            }

        }
    }
}
