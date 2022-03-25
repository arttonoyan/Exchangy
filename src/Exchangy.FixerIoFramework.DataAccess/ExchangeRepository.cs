using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class ExchangeRepository : IExchangeRepository
    {

        public async Task Insert(CurrencyRequests currencyRequests)
        {
            DbContextOptions<ExchangyDbContext> options = new DbContextOptionsBuilder<ExchangyDbContext>()
            .UseInMemoryDatabase(databaseName: "ExchangeDb")
            .Options;

            using ExchangyDbContext context = new ExchangyDbContext(options);

            await context.CurrencyRequests.AddAsync(currencyRequests);
            await context.SaveChangesAsync();
        }

        public async Task<List<CurrencyRequests>> Get()
        {
            DbContextOptions<ExchangyDbContext> options = new DbContextOptionsBuilder<ExchangyDbContext>()
            .UseInMemoryDatabase(databaseName: "ExchangeDb")
            .Options;

            using ExchangyDbContext context = new ExchangyDbContext(options);

            List<CurrencyRequests> currRequests = await context.CurrencyRequests
                .Include(x => x.Rates)
                .ToListAsync();

            return currRequests;
        }
    }
}
