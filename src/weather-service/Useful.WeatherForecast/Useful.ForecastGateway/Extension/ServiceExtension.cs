using Hangfire.Dashboard;
using Hangfire;
using Useful.ForecastCommon.Contract;
using Useful.ForecastGateway.Configuration;
using Useful.ForecastGateway.Hangfire;
using Useful.ForecastRepository;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Service;
using Useful.ForecastTaskScheduler;
using Microsoft.Extensions.Configuration;

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

    public static void ConfigureHangFire(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var dbConfig = configuration.GetSection(DatabaseConfiguration.Configuration).Get<DatabaseConfiguration>();
        builder.Services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(dbConfig?.HangFireDbConnectionString));

        builder.Services.AddSingleton<IDashboardAuthorizationFilter, HangfireAuthorizationFilter>();
        builder.Services.AddHangfireServer();
    }
}