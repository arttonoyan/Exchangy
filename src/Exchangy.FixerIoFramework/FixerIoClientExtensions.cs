using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework
{
    public static class FixerIoClientExtensions
    {
        public static Task<IFixerResponse> LatestAsync(this IFixerIoClient client)
        {
            var query = client.BuildQuery();
            return client.GetAsync("latest", query);
        }

        public static Task<IFixerResponse> LatestAsync(this IFixerIoClient client, IEnumerable<string> symbols)
        {
            var value = string.Join(',', symbols);
            var query = client.BuildQuery(KeyValuePair.Create("symbols", value));
            return client.GetAsync("latest", query);
        }

        public static Task<IFixerResponse> LatestAsync(this IFixerIoClient client, params string[] symbols) =>
            client.LatestAsync(symbols.AsEnumerable());

        public static Task<IFixerResponse> LatestAsync(this IFixerIoClient client, params Symbols[] symbols) =>
            client.LatestAsync(symbols.Select(p => p.ToString()));
    }
}
