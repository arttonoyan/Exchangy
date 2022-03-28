using Exchangy.FixerIoFramework.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FixerIoDataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryExchangeDbContext(this IServiceCollection services)
        {
            return services.AddExchangeDbContext(options => options.UseInMemoryDatabase(databaseName: "ExchangeDb"));
        }

        public static IServiceCollection AddSqliteExchangeDbContext(this IServiceCollection services)
        {
            return services.AddExchangeDbContext(options => options.UseSqlite("Data Source=ExchangeDb"));
        }

        public static IServiceCollection AddExchangeDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
        {
            if (optionsAction == null)
            {
                services.AddDbContext<ExchangyContext>();
            }
            else
            {
                services.AddDbContext<ExchangyContext>(optionsAction);
            }

            services.AddScoped<IExchangeRepository, ExchangeRepository>();
            return services;
        }
    }
}
