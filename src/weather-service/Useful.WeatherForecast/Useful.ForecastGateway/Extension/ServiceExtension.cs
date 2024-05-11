using MongoDB.Driver;
using Useful.ForecastCommon.Contract;
using Useful.ForecastGateway.Configuration;
using Useful.ForecastRepository;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Service;

namespace Useful.ForecastGateway.Extension;

public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddSingleton<ICosmosDbContext, CosmosDbContext>();
        service.AddSingleton<IForecastGatewayConfiguration, ForecastGatewayConfiguration>();
        service.AddTransient<IOpenWeatherGeoRestService, OpenWeatherRestGeoService>();
        service.AddTransient<IOpenWeatherRestService, OpenWeatherRestService>();
    }
}