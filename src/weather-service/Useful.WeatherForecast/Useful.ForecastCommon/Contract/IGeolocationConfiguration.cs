namespace Useful.ForecastCommon.Contract;

public interface IGeolocationConfiguration
{
    string? GeolocationApiKey { get; set; }
    string? GeolocationBaseUrl { get; set; }
}