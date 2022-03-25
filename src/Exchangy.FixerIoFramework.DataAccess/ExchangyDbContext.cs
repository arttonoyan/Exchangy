using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class ExchangyDbContext : DbContext
    {
        public ExchangyDbContext(DbContextOptions<ExchangyDbContext> options)
        : base(options)
        { }

        public DbSet<CurrencyRequests> CurrencyRequests { get; set; }
        public DbSet<RateResults> RateResults { get; set; }
    }
}
