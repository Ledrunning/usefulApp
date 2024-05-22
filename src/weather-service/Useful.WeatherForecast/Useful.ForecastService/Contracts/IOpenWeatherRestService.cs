using Useful.ForecastService.Models;

namespace Useful.ForecastService.Contracts;

public interface IOpenWeatherRestService
{
    Task<MainWeather> GetWeatherFromOpenWeatherApi(string city, CancellationToken token);
    public string Location { get; set; }
}