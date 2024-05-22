using Microsoft.AspNetCore.Mvc;
using Useful.ForecastService.Contracts;
using Useful.ForecastService.Models;

namespace Useful.ForecastGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private readonly IOpenWeatherRestService _forecastService;

        public WeatherForecastController(IOpenWeatherRestService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        [Route(nameof(GetWeather))]
        public async Task<MainWeather> GetWeather(string city, CancellationToken token)
        {
            return await _forecastService.GetWeatherFromOpenWeatherApi(city, token);
        }

        [HttpGet]
        [Route(nameof(GetSavedWeatherByDateTime))]
        public async Task<MainWeather> GetSavedWeatherByDateTime(string dateTime, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
