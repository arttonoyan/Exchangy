using Exchangy.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataAccessServiceCollectionExtensions
    {
        public static IServiceCollection AddExchangyDataAccess(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
            => services
                .AddDbContext<ExchangyContext>(optionsAction)
                .AddScoped<IExchangeRepository, ExchangeRepository>();

        public static IServiceCollection AddExchangyDataAccess(this IServiceCollection services, Action<DataAccessOptions> optionsAction)
        {
            var options = new DataAccessOptions();
            optionsAction.Invoke(options);

            return options.DbType switch
            {
                //DbType.Sql => AddExchangyDataAccess(services, cfg => cfg.UseSql(options.ConnectionString)),
                DbType.Sqlite => AddExchangyDataAccess(services, cfg => cfg.UseSqlite(options.ConnectionString)),
                DbType.Sql => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }
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
