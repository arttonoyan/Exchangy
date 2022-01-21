using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework
{
    public class FixerIoClient : IFixerIoClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessKey;
        public FixerIoClient(HttpClient httpClient, FixerOptions options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.BaseUrl);
            _accessKey = options.AccessKey;
        }

        public Task<IFixerResponse> GetAsync(string path, string request = null)
        {
            try
            {
                return InnerGetAsync(path, request);
            }
            catch
            {
                //TODO [log] [Artem Tonoyan] [1/20/2022]: Add log.
                return Task.FromResult<IFixerResponse>(new FixerResponse
                {
                    HttpStatusCode = System.Net.HttpStatusCode.BadRequest
                });
            }
        }

        private async Task<IFixerResponse> InnerGetAsync(string path, string query)
        {
            var request = HttpQueryBuilder.BuildRequest(path, KeyValuePair
                .Create("access_key", _accessKey), query);
            using var response = await _httpClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return new FixerResponse
                {
                    HttpStatusCode = response.StatusCode,
                    Content = content,
                    Currency = JsonSerializer.Deserialize<Currency>(content, JsonHelper.DefaultOptions)
                };
            }

            return new FixerResponse
            {
                HttpStatusCode = response.StatusCode
            };
        }
    }
}
