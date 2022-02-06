using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api
{
    public class Currency
    {
        public string StartDate { get; set; }
        public string TimeSign { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyCodeL { get; set; }
        public int Units { get; set; }
        public double Amount { get; set; }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static async Task ProcessRepositories()
        {
            //var jsonOptions = new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //};

            Console.OutputEncoding = Encoding.UTF8;

            List<Currency> currencies = new List<Currency>();

            var stringTask = client.GetStringAsync("https://bank.gov.ua/NBU_Exchange/exchange?json");
            var msg = await stringTask;
            Console.Write(msg);

            var streamTask = client.GetStreamAsync("https://bank.gov.ua/NBU_Exchange/exchange?json");
            var repositories = await JsonSerializer.DeserializeAsync<List<Currency>>(await streamTask);

            foreach (var elm in repositories)
            {
                if (elm.CurrencyCode == "840" || elm.CurrencyCode == "978" || elm.CurrencyCode == "643" ||
                    elm.CurrencyCode == "985" || elm.CurrencyCode == "756" || elm.CurrencyCode == "826")
                {
                    currencies.Add(elm);
                }
            }

            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy"));

            foreach (var item in currencies)
            {
                Console.WriteLine();
                Console.WriteLine("{0} | {1} | {2}", item.CurrencyCode, item.CurrencyCodeL, item.Amount);
                Console.WriteLine();
            }
        }

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
    }
}
