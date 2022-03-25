using Exchangy.FixerIoFramework.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.ConsoleTestApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        private static IRepository<Currency> _repository;

        static async Task Main(string[] args)
        {
            Configure();

            var client = _serviceProvider.GetService<IFixerIoClient>();
            //var query = client.BuildQuery(KeyValuePair.Create("symbols", "USD,AUD,CAD,PLN,MXN"));
            //var res = await client.GetAsync("latest", query);
            var res1 = await client.LatestAsync(Symbols.AED, Symbols.AFN, Symbols.AMD);


            _repository.Add(res1.Currency);
            _repository.Save();

        }

        private static void Configure()
        {
            var services = new ServiceCollection();

            services.AddFixerIoClient(options => 
            {
                options.BaseUrl = "http://data.fixer.io/api/";
                options.AccessKey = "5bb9e34a850d88ee925a582135d75262";
            });

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
