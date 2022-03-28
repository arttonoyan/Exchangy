using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Exchangy.DataAccess;

namespace Exchangy.FixerIoFramework.ConsoleTestApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        //private void SaveCurrencyRates(IFixerResponse result)
        //{
        //    CurrencyRequests currRequests = new()
        //    {
        //        BaseCurrency = result.Currency.Base,
        //        RequestDate = Convert.ToDateTime(result.Currency.Date)
        //    };

        //    if (result.Currency.Rates.Count > 0)
        //    {
        //        currRequests.Rates = new();
        //        foreach (KeyValuePair<string, double> rate in result.Currency.Rates)
        //        {
        //            currRequests.Rates.Add(new RateResults
        //            {
        //                Currency = rate.Key,
        //                Rate = rate.Value
        //            });
        //        }
        //    }

        //     _exchangeRepository.Insert(currRequests).Wait();
        //     //var a = _exchangeRepository.Get().Result;
        //}
        static async Task Main(string[] args)
        {
            Configure();
            var client = _serviceProvider.GetService<IFixerIoClient>();
            //var query = client.BuildQuery(KeyValuePair.Create("symbols", "USD,AUD,CAD,PLN,MXN"));
            //var res = await client.GetAsync("latest", query);
            var result = await client.LatestAsync(Symbols.AED, Symbols.AFN, Symbols.AMD);

            var context = _serviceProvider.GetService<IExchangeRepository>();

            DataAccess.Currency currRequest = new()
            {
                BaseCurrency = result.Currency.Base,
                RequestDate = Convert.ToDateTime(result.Currency.Date)
            };

            if (result.Currency.Rates.Count > 0)
            {
                currRequest.Rates = new();
                foreach (var rate in result.Currency.Rates)
                {
                    currRequest.Rates.Add(new Rate
                    {
                        Currency = rate.Key,
                        Value = rate.Value
                    });
                }
            }

            await context.AddAsync(currRequest);
            List<DataAccess.Currency> CurrencyRequests = await context
                .GetAsync()
                .ToListAsync();
        }

        private static void Configure()
        {
            var services = new ServiceCollection();

            services.AddFixerIoClient(options =>
            {
                options.BaseUrl = "http://data.fixer.io/api/";
                options.AccessKey = "5bb9e34a850d88ee925a582135d75262";
            });

            services.AddSqliteExchangyDataAccess();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
