using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly ExchangyContext _context;
        public ExchangeRepository(ExchangyContext context)
        {
            _context = context;
        }

        public async Task Add(CurrencyRequest currencyRequests)
        {
            await _context.CurrencyRequests.AddAsync(currencyRequests);
            await _context.SaveChangesAsync();
        }

        public IAsyncEnumerable<CurrencyRequest> Get()
        {
            return _context.CurrencyRequests.Include(x => x.Rates).AsAsyncEnumerable();
        }
    }
}
