using Useful.ForecastGateway.Configuration;

namespace Useful.ForecastGateway.Extension;

public static class ConfigurationExtension
{
    public static void ConfigureSettings(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<GeolocationConfiguration>(
            configuration.GetSection(GeolocationConfiguration.Configuration));

        service.Configure<OpenWeatherApiConfiguration>(
            configuration.GetSection(OpenWeatherApiConfiguration.Configuration));
    }
}