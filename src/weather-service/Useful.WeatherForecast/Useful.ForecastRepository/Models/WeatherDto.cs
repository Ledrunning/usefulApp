namespace Useful.ForecastRepository.Models;

public record WeatherDto
{
    public float Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}