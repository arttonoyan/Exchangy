using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public interface IExchangeRepository
    {
        IAsyncEnumerable<CurrencyRequest> Get();
        Task Add(CurrencyRequest currencyRequests);
    }
}