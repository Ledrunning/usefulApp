namespace Useful.ForecastCommon.Contract;

public interface IForecastGatewayConfiguration
{
    public string? DbConnectionString { get; set; }
    public string? DbName { get; set; }
}