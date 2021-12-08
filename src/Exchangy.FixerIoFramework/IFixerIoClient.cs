using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework
{
    public interface IFixerIoClient
    {
        string BuildQuery(params KeyValuePair<string, string>[] requestParams);
        Task<IFixerResponse> GetAsync(string path, string request);
    }
}
