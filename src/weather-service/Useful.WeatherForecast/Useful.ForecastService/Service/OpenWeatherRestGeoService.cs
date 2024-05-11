using RestSharp;
using Useful.ForecastCommon.Contract;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Models.GeoApiModel;

namespace Useful.ForecastService.Service;

public class OpenWeatherRestGeoService : BaseService, IOpenWeatherGeoRestService
{
    private readonly string? _apiKey;
    private readonly int _cityLimit;

    public OpenWeatherRestGeoService(IForecastGatewayConfiguration configuration) : base(configuration)
    {
        _apiKey = configuration.ApiKey;
        _cityLimit = configuration.GeoCityLimit;
    }

    //http://api.openweathermap.org/geo/1.0/direct?q=London&limit=5&appid={API key}
    //May be country two letter code 
    public async Task<List<GeoData>> GetCityCoordinates(string city, CancellationToken token)
    {
        var url = new Uri($"{BaseUrl}{city}&limit={_cityLimit}&appid={_apiKey}");
        var client = new RestClient(SetOptions(url));
        var request = new RestRequest();
        var response = await client.ExecuteAsync(request, token);

        return GetContent<List<GeoData>>(response, url.AbsoluteUri);
    }
}