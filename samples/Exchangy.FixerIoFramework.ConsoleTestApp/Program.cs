using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.ConsoleTestApp
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        private static async Task Main(string[] args)
        {
            Configure();
            IFixerIoClient client = _serviceProvider.GetService<IFixerIoClient>();
            //var query = client.BuildQuery(KeyValuePair.Create("symbols", "USD,AUD,CAD,PLN,MXN"));
            //var res = await client.GetAsync("latest", query);
            IFixerResponse result = await client.LatestAsync(Symbols.AED, Symbols.AFN, Symbols.AMD);
        }

        private static void Configure()
        {
            ServiceCollection services = new();

            services.AddFixerIoClient(options =>
            {
                options.BaseUrl = "http://data.fixer.io/api/";
                options.AccessKey = "5bb9e34a850d88ee925a582135d75262";
            });

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
