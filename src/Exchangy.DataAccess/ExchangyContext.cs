using Exchangy.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Exchangy.DataAccess
{
    public class ExchangyContext : DbContext
    {
        public ExchangyContext(DbContextOptions<ExchangyContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyEntityTypeConfiguration).Assembly);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
