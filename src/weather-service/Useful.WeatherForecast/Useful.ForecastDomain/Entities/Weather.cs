namespace Useful.ForecastDomain.Entities;

public record Weather
{
    public Guid Id { get; set; }
    public float Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}