using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exchangy.DataAccess.Extensions.DependencyInjection
{
    public static class DataAccessServiceCollectionExtensions
    {
        //TODO [Artyom Tonoyan] [28/03/2022]: Need to Remove
        public static IServiceCollection AddInMemoryExchangyDataAccess(this IServiceCollection services)
        {
            return AddExchangyDataAccess(services, options => options.UseInMemoryDatabase(databaseName: "ExchangeDb"));
        }

        //TODO [Artem Tonoyan] [28/03/2022]: Need to Remove
        public static IServiceCollection AddSqliteExchangyDataAccess(this IServiceCollection services)
        {
            return AddExchangyDataAccess(services, options => options.UseSqlite("Data Source=ExchangeDb"));
        }

        internal static IServiceCollection AddExchangyDataAccess(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
            => services
                .AddDbContext<ExchangyContext>(optionsAction)
                .AddScoped<IExchangeRepository, ExchangeRepository>();

        //public static IServiceCollection AddExchangyDataAccess(this IServiceCollection services, Action<DbContextOptionsBuilder<DataAccessOptions>> optionsAction)
        //    => services
        //        .AddDbContext<ExchangyContext>(o => optionsAction)
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
