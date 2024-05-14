using Hangfire.Dashboard;
using Hangfire;
using Useful.ForecastCommon.Contract;
using Useful.ForecastGateway.Configuration;
using Useful.ForecastGateway.Hangfire;
using Useful.ForecastRepository;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Service;
using Useful.ForecastTaskScheduler;

namespace Useful.ForecastGateway.Extension;

public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddSingleton<IForecastGatewayConfiguration, ForecastGatewayConfiguration>();
        service.AddSingleton<ICosmosDbContext, CosmosDbContext>();
        service.AddTransient<IOpenWeatherGeoRestService, OpenWeatherRestGeoService>();
        service.AddTransient<IOpenWeatherRestService, OpenWeatherRestService>();
        //Configure task scheduler
        service.AddTransient<ForecastDataUploader>();
        service.AddTransient<ForecastScheduler>();
    }

    // TODO OSM: you should use Database!
    public static void ConfigureHangFire(this WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings());
//            .UseMemoryStorage());

        builder.Services.AddSingleton<IDashboardAuthorizationFilter, HangfireAuthorizationFilter>();
        builder.Services.AddHangfireServer();
    }
}