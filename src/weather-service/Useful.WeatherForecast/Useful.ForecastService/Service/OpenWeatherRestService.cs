using Microsoft.Extensions.Logging;
using RestSharp;
using Useful.ForecastCommon.Contract;
using Useful.ForecastCommon.RestService;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Models;

namespace Useful.ForecastService.Service;

public class OpenWeatherRestService : BaseService, IOpenWeatherRestService
{
    private readonly IOpenWeatherGeoRestService _geoRestService;
    private readonly ILogger<OpenWeatherRestService> _logger;

    public string Location { get; set; }

    public OpenWeatherRestService(ILogger<OpenWeatherRestService> logger, IOpenWeatherGeoRestService geoRestService,
        IForecastGatewayConfiguration configuration)
        : base(configuration)
    {
        _geoRestService = geoRestService;
        _logger = logger;
    }

    //URL - https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}
    public async Task<MainWeather> GetWeatherFromOpenWeatherApi(string city, CancellationToken token)
    {
        try
        {
            Location = city;
            var cityInfoList = await _geoRestService.GetCityCoordinates(city, token);
            var cityInfo = cityInfoList.Select(data => data).FirstOrDefault();

            var url = new Uri($"{BaseUrl}lat={cityInfo?.Lat}&lon={cityInfo?.Lon}&appid={ApiKey}");
            var client = new RestClient(SetOptions(url));
            var request = new RestRequest();
            var response = await client.ExecuteAsync(request, token);

            return GetContent<MainWeather>(response);
        }
        catch (Exception e)
        {
            _logger.LogError("Error retrieve data from OpenWeatherApi {e}:", e);
            throw;
        }
    }
}