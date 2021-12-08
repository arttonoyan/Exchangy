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
            _accessKey = options.AccessKey;
        }

        public Task<IFixerResponse> GetAsync(string path, string request)
        {
            try
            {
                return InnerGetAsync(path, request);
            }
            catch (Exception ex)
            {
                IFixerResponse response = new FixerResponse();
                return Task.FromResult(response);
            }
        }

        private async Task<IFixerResponse> InnerGetAsync(string path, string query)
        {
            var request = $"{path}?{query}";
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

        public string BuildQuery(params KeyValuePair<string, string>[] requestParams)
        {
            var request = $"access_key={_accessKey}";
            if (requestParams != null && requestParams.Length > 0)
            {
                var builder = new StringBuilder();
                foreach (var (key, value) in requestParams)
                {
                    builder.Append(key).Append('=').Append(value).Append('&');
                }

                request = $"{request}&{builder}";
            }

            return request.TrimEnd('&');
        }
    }
}
