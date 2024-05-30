namespace Useful.ForecastCommon.Contract;

public interface IForecastGatewayConfiguration : IDatabaseConfiguration, IOpenWeatherApiConfiguration, IGeolocationConfiguration
{
    
}