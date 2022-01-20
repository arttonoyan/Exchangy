using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework
{
    public interface IFixerIoClient
    {
        Task<IFixerResponse> GetAsync(string path, string request = null);
    }
}
