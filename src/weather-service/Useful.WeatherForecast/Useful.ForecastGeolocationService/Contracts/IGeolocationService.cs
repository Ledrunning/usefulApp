using Useful.ForecastGeolocationService.Model;

namespace Useful.ForecastGeolocationService.Contracts;

public interface IGeolocationService
{
    Task<Geolocation> GetGeolocationAsync(string ipAddress, CancellationToken token);
}