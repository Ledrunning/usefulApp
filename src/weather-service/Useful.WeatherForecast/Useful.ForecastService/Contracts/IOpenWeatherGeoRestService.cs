using Useful.ForecastService.Models.GeoApiModel;

namespace Useful.ForecastService.Contracts;

public interface IOpenWeatherGeoRestService
{
    public Task<List<GeoData>> GetCityCoordinates(string city, CancellationToken token);
}