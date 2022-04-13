using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exchangy.DataAccess.Extensions.DependencyInjection
{
    public static class DataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddExchangyDataAccess(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
            => services
                .AddDbContext<ExchangyContext>(optionsAction)
                .AddScoped<IExchangeRepository, ExchangeRepository>();

        //public static IServiceCollection AddExchangyDataAccess(this IServiceCollection services, Action<DbContextOptionsBuilder<DataAccessOptions>> optionsAction)
        //    => services
        //        .AddDbContext<ExchangyContext>(o => o = optionsAction)
        //        .AddScoped<IExchangeRepository, ExchangeRepository>();
    }

    public class DataAccessOptions
    {
        public DbType DbType { get; set; }
        public string ConnectionString { get; set; } = null!;
    }

    public enum DbType : byte
    {
        Sql = 1,
        Sqlite = 2
    }
}
