using Exchangy.FixerIoFramework;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FixerIoServiceCollectionExtensions
    {
        public static IServiceCollection AddFixerIoClient(this IServiceCollection services, string name, Action<FixerOptions> optionsAction)
        {
            var options = new FixerOptions();
            optionsAction.Invoke(options);
            return services.AddFixerIoClient(name, options);
        }

        public static IServiceCollection AddFixerIoClient(this IServiceCollection services, string name, FixerOptions options)
        {
            services
                .AddSingleton(options)
                .AddHttpClient<IFixerIoClient, FixerIoClient>(name)
                .AddPolicyHandler(GetRetryPolicy());
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
