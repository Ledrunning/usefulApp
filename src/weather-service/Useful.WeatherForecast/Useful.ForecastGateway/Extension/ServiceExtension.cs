﻿using Useful.ForecastCommon.Contract;
using Useful.ForecastGateway.Configuration;
using Useful.ForecastRepository;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Service;

namespace Useful.ForecastGateway.Extension;

public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddTransient<ICosmosDbContext, CosmosDbContext>();
        service.AddTransient<IForecastGatewayConfiguration, ForecastGatewayConfiguration>();
        service.AddTransient<IOpenWeatherRestService, OpenWeatherRestService>();
    }
}