using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.DataAccess
{
    public interface IExchangeRepository
    {
        IAsyncEnumerable<Currency> GetAsync();
        Task AddAsync(Currency currencyRequests);
    }
}