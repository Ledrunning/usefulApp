using Useful.ForecastCommon.Contract;

namespace Useful.ForecastGateway.Configuration;

public class ForecastGatewayConfiguration : IForecastGatewayConfiguration
{
    public string? DbConnectionString { get; set; }
    public string? DbName { get; set; }
    public string? BaseUrl { get; set; }
    public string? BaseGeoUrl { get; set; }
    public string? ApiKey { get; set; }
    public int TimeOut { get; set; }
    public int GeoCityLimit { get; set; }
    public string? GeolocationApiKey { get; set; }
    public string? GeolocationBaseUrl { get; set; }
}