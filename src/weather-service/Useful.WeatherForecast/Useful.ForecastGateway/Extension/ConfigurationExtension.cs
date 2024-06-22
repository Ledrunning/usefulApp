using Useful.ForecastCommon.Contract;
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

        var forecastConfig = new ForecastGatewayConfiguration();
        configuration.GetSection(GeolocationConfiguration.Configuration).Bind(forecastConfig);
        configuration.GetSection(OpenWeatherApiConfiguration.Configuration).Bind(forecastConfig);
        service.AddSingleton<IForecastGatewayConfiguration>(forecastConfig);
    }
}