namespace Useful.CryptoCurrencyCommon.Contracts;

public interface ICryptoCurrencyGatewayConfiguration
{
    public string? BaseUrl { get; set; }
    public int? Timeout { get; set; }
}