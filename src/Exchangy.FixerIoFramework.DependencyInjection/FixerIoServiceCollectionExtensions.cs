using Exchangy.FixerIoFramework;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FixerIoServiceCollectionExtensions
    {
        public static IServiceCollection AddFixerIoClient(this IServiceCollection services, Action<FixerOptions> optionsAction)
        {
            var options = new FixerOptions();
            optionsAction.Invoke(options);
            return services.AddFixerIoClient(options);
        }

        public static IServiceCollection AddFixerIoClient(this IServiceCollection services, FixerOptions options)
        {
            services
                .AddSingleton(options)
                .AddHttpClient<IFixerIoClient, FixerIoClient>((provider, client) =>
                {
                    var options = provider.GetService<FixerOptions>();
                    client.BaseAddress = new Uri(options.BaseUrl);
                });
            //.AddPolicyHandler(GetRetryPolicy());
            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
