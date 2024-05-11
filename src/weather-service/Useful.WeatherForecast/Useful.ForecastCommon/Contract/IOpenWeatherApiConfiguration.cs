namespace Useful.ForecastCommon.Contract;

public interface IOpenWeatherApiConfiguration
{
    public string? BaseUrl { get; set; }
    public string? BaseGeoUrl { get; set; }
    public string? ApiKey { get; set; }
    public int TimeOut { get; set; }
    public int GeoCityLimit { get; set; }
}