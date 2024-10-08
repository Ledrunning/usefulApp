using Useful.CryptoCurrencyCommon.Contracts;

namespace Useful.CryptoCurrencyGateway.Configuration;

public class ConcapApiConfiguration : ICryptoCurrencyGatewayConfiguration
{
    public const string SectionName = "ConcapApi";
    public string? BaseUrl { get; set; }
    public int? Timeout { get; set; }

}