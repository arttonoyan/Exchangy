using Exchangy.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Exchangy.DataAccess.Extensions.DependencyInjection;

namespace Exchangy.DataAccess.ConsoleTestApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static async Task Main(string[] args)
        {
            Configure();

            var context = _serviceProvider.GetService<IExchangeRepository>();

            Currency currency = new()
            {
                BaseCurrency = "AMD",
                RequestDate = DateTime.Now
            };

            Dictionary<string, double> rates = new()
            {
                { "USD", 480d },
                { "CAD", 500d },
                { "EUR", 520d }
            };
            currency.Rates = new();

            foreach (var rate in rates)
            {
                currency.Rates.Add(new Rate
                {
                    Currency = rate.Key,
                    Value = rate.Value
                });
            }

            await context.AddAsync(currency);
            List<Currency> Currencies = await context
                .GetAsync()
                .ToListAsync();
        }

        private static void Configure()
        {
            var services = new ServiceCollection();

            services.AddSqliteExchangyDataAccess();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
