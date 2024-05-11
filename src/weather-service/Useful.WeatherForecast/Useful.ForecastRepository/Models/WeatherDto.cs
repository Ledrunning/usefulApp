namespace Useful.ForecastRepository.Models;

public record WeatherDto
{
    public Guid Id { get; set; }
    public float Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}