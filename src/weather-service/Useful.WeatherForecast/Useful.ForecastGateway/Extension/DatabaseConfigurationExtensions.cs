using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Useful.ForecastGateway.Configuration;

namespace Useful.ForecastGateway.Extension
{
    public static class DatabaseConfigurationExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<DatabaseConfiguration>(configuration.GetSection(nameof(DatabaseConfiguration)));
            services.AddSingleton<IMongoClient>(provider =>
            {
                var dbConfig = provider.GetRequiredService<IOptions<DatabaseConfiguration>>().Value;
                var connectionString = dbConfig.DbConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Database connection string is not configured.");
                }
                return new MongoClient(connectionString);
            });
        }
    }
}
