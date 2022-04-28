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

        public async Task AddAsync(Currency currencies)
        {
            await _context.Currencies.AddAsync(currencies);
            await _context.SaveChangesAsync();
        }

        public IAsyncEnumerable<Currency> GetAsync()
        {
            return _context.Currencies
                .Include(x => x.Rates)
                .AsAsyncEnumerable();
        }
    }
}
