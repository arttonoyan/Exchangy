using Exchangy.FixerIoFramework.DataAccess;
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
        private readonly IExchangeRepository _exchangeRepository;
        private readonly string _accessKey;
        public FixerIoClient(HttpClient httpClient, FixerOptions options, IExchangeRepository exchangeRepository)
        {
            _httpClient = httpClient;
            _exchangeRepository = exchangeRepository;
            _httpClient.BaseAddress = new Uri(options.BaseUrl);
            _accessKey = options.AccessKey;
        }

        public Task<IFixerResponse> GetAsync(string path, string request = null)
        {
            try
            {
                Task<IFixerResponse> fixerResponse = InnerGetAsync(path, request);
                SaveCurrencyRates(fixerResponse.Result);
                return fixerResponse;
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

        private void SaveCurrencyRates(IFixerResponse result)
        {
            CurrencyRequests currRequests = new()
            {
                BaseCurrency = result.Currency.Base,
                RequestDate = Convert.ToDateTime(result.Currency.Date)
            };

            if (result.Currency.Rates.Count > 0)
            {
                currRequests.Rates = new();
                foreach (KeyValuePair<string, double> rate in result.Currency.Rates)
                {
                    currRequests.Rates.Add(new RateResults
                    {
                        Currency = rate.Key,
                        Rate = rate.Value
                    });
                }
            }

             _exchangeRepository.Insert(currRequests).Wait();
             //var a = _exchangeRepository.Get().Result;
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
