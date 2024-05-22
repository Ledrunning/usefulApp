using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Useful.ForecastCommon.Contract;
using Useful.ForecastGateway.Configuration;

namespace Useful.ForecastGateway.Extension
{
    public static class DatabaseConfigurationExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<DatabaseConfiguration>(configuration.GetSection(DatabaseConfiguration.Configuration));
            services.AddSingleton<IDatabaseConfiguration>(sp =>
                sp.GetRequiredService<IOptions<DatabaseConfiguration>>().Value);

            var dbConfig = configuration.GetSection(DatabaseConfiguration.Configuration).Get<DatabaseConfiguration>();
            services.AddSingleton<IMongoClient>(_ => new MongoClient(dbConfig?.DbConnectionString));
        }
    }
}
