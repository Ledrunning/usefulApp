using Useful.ForecastCommon.Contract;

namespace Useful.ForecastGateway.Configuration;

public class GeolocationConfiguration : IGeolocationConfiguration
{
    public static readonly string Configuration = "GeolocationApi";
    public string? GeolocationApiKey { get; set; }
    public string? GeolocationBaseUrl { get; set; }
}