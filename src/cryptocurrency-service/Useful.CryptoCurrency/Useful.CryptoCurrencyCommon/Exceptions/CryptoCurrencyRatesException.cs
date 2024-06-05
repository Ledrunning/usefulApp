namespace Useful.CryptoCurrencyCommon.Exceptions;

public class CryptoCurrencyRatesException : Exception
{
    private readonly string? _errorCode;
    private readonly string? _errorMessage;

    public CryptoCurrencyRatesException(string message) : base(message)
    {
    }

    public CryptoCurrencyRatesException(string message, string? errorCode, string? errorMessage) : base(message)
    {
        _errorCode = errorCode;
        _errorMessage = errorMessage;
    }
}