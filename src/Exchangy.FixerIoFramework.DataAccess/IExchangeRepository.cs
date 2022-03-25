using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public interface IExchangeRepository
    {
        Task<List<CurrencyRequests>> Get();
        Task Insert(CurrencyRequests currencyRequests);
    }
}