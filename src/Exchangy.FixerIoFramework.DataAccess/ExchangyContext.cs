using Exchangy.FixerIoFramework.DataAccess.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class ExchangyContext : DbContext
    {
        public ExchangyContext() : base()
        { }
        public ExchangyContext(DbContextOptions<ExchangyContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlite("Data Source=ExchangeDefaultDb");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyRequestEntityTypeConfiguration).Assembly);
        }

        public DbSet<CurrencyRequest> CurrencyRequests { get; set; }
        public DbSet<RateResult> RateResults { get; set; }
    }
}
