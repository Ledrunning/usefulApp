namespace Useful.ForecastCommon.Exception;

public class WeatherForecastException : System.Exception
{
    private readonly string? _errorCode;
    private readonly string? _errorMessage;

    public WeatherForecastException(string message) : base(message)
    {
    }

    public WeatherForecastException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }

    public WeatherForecastException(string message, string errorCode, string errorMessage) : base(message)
    {
        _errorCode = errorCode;
        _errorMessage = errorMessage;
    }
}