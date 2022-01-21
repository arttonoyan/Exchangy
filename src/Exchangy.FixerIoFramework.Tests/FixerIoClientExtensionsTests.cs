using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exchangy.FixerIoFramework.Tests
{
    public class FixerIoClientExtensionsTests
    {
        private IServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddFixerIoClient(cfg =>
            {
                cfg.AccessKey = "testKey";
                cfg.BaseUrl = "http://data.fixer.io/api/";
            });

            services.AddHttpClient<IFixerIoClient, FixerIoClientMock>();

            return services.BuildServiceProvider();
        }

        [Fact]
        public async Task LatestAsyncTest()
        {
            var provider = Configure();
            var client = provider.GetService<IFixerIoClient>();
            var res = await client.LatestAsync();

            Assert.Equal("latest-", res.Content);
        }

        [Fact]
        public async Task LatestAsyncWithArgTest()
        {
            var provider = Configure();
            var client = provider.GetService<IFixerIoClient>();
            var res = await client.LatestAsync("A1", "A2", "A3");

            Assert.Equal("latest-symbols=A1,A2,A3", res.Content);
        }

        public class FixerIoClientMock : IFixerIoClient
        {
            public FixerIoClientMock(HttpClient httpClient) { }

            public Task<IFixerResponse> GetAsync(string path, string query)
            {
                return Task.FromResult<IFixerResponse>(new FixerResponse
                {
                    Content = $"{path}-{query}",
                    HttpStatusCode = System.Net.HttpStatusCode.OK
                }); ;
            }
        }
    }
}
