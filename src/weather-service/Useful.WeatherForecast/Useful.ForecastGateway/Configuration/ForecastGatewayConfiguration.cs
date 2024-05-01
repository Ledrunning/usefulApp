using Useful.ForecastCommon.Contract;

namespace Useful.ForecastGateway.Configuration;

public class ForecastGatewayConfiguration : IForecastGatewayConfiguration
{
    public static readonly string Configuration = "ForecastGatewayConfiguration";
    public string? DbConnectionString { get; set; }
    public string? DbName { get; set; }
}