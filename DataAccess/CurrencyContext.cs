using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    internal class CurrencyContext : DataContext
    {
        public CurrencyContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
    }
}
