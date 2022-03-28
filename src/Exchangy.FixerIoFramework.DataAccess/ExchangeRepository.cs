using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.DataAccess
{
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly ExchangyContext _context;
        public ExchangeRepository(ExchangyContext context)
        {
            _context = context;
        }

        public Task AddAsync(Currency currencyRequests) =>
            ResilientTransaction.New(_context)
                .ExecuteAsync(async () =>
                {
                    await _context.CurrencyRequests.AddAsync(currencyRequests);
                    await _context.SaveChangesAsync();
                });

        public IAsyncEnumerable<Currency> GetAsync()
        {
            return _context.CurrencyRequests
                .Include(x => x.Rates)
                .AsAsyncEnumerable();
        }
    }
}
