using Useful.ForecastCommon.Contract;

namespace Useful.ForecastGateway.Configuration;

public class GeolocationConfiguration : IGeolocationConfiguration
{
    public static readonly string Configuration = "GeolocationApi";
    public string? ApiKey { get; set; }
    public string? BaseUrl { get; set; }
}