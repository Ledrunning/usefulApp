namespace Useful.ForecastCommon.Contract;

public interface IDatabaseConfiguration
{
    public string? DbConnectionString { get; set; }
    public string? DbName { get; set; }
}