using Useful.ForecastRepository.Models;
using Useful.ForecastService.Models;

namespace Useful.ForecastService;

public class WeatherMapper
{
    public static WeatherDto MapToWeatherDto(Main main)
    {
        return new WeatherDto
        {
            Temperature = main.Temp,
            Pressure = main.Pressure,
            Humidity = main.Humidity
        };
    }
}