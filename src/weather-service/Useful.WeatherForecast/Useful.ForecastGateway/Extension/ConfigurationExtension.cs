using Useful.ForecastGateway.Configuration;

namespace Useful.ForecastGateway.Extension;

public static class ConfigurationExtension
{
    public static void ConfigureSettings(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<OpenWeatherApiConfiguration>(configuration.GetSection(OpenWeatherApiConfiguration.Configuration));
        service.Configure<DatabaseConfiguration>(configuration.GetSection(DatabaseConfiguration.Configuration));
    }
}