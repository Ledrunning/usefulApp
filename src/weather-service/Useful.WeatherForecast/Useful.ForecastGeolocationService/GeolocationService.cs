using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Runtime;
using Useful.ForecastCommon.Contract;
using Useful.ForecastCommon.RestService;
using Useful.ForecastGeolocationService.Contracts;
using Useful.ForecastGeolocationService.Model;

namespace Useful.ForecastGeolocationService;

// https://ipstack.com/signup/free
public class GeolocationService : BaseService, IGeolocationService
{
    private readonly IForecastGatewayConfiguration _configuration;
    private readonly ILogger<IGeolocationService> _logger;

    //TODO OSM Think about two base urls
    public GeolocationService(IForecastGatewayConfiguration configuration, ILogger<IGeolocationService> logger) : base(configuration)
    {
        _logger = logger;
        _configuration = configuration; // TODO Add["IPStack:ApiKey"];
    }

    // http://api.ipstack.com/{ipAddress}?access_key={_configuration}
    public async Task<Geolocation> GetGeolocationAsync(string ipAddress, CancellationToken token)
    {
        var url = new Uri($"{BaseUrl}{ipAddress}?access_key={_configuration.GeolocationApiKey}");
        var client = new RestClient(SetOptions(url));
        var request = new RestRequest();
        var response = await client.ExecuteAsync(request, token);

        return GetContent<Geolocation>(response);
    }
}