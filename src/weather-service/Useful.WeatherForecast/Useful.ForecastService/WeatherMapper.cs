using Useful.ForecastRepository.Models;
using Useful.ForecastService.Models;
using Weather = Useful.ForecastDomain.Entities.Weather;

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

    public static Weather MapToWeather(Main main)
    {
        return new Weather
        {
            Temperature = main.Temp, 
            Pressure = main.Pressure, 
            Humidity = main.Humidity
        };
    }
}