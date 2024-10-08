using Microsoft.Extensions.Options;
using Useful.ForecastCommon.Contract;
using Useful.ForecastGateway.Configuration;

namespace Useful.ForecastGateway.Extension;

public static class ConfigurationExtension
{
    public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GeolocationConfiguration>(
            configuration.GetSection(GeolocationConfiguration.Configuration));

        services.Configure<OpenWeatherApiConfiguration>(
            configuration.GetSection(OpenWeatherApiConfiguration.Configuration));

        services.Configure<ForecastGatewayConfiguration>(config =>
        {
            configuration.GetSection(GeolocationConfiguration.Configuration).Bind(config);
            configuration.GetSection(OpenWeatherApiConfiguration.Configuration).Bind(config);
            configuration.GetSection(DatabaseConfiguration.Configuration).Bind(config);
        });

        services.AddSingleton<IForecastGatewayConfiguration>(sp =>
            sp.GetRequiredService<IOptions<ForecastGatewayConfiguration>>().Value);
    }
}