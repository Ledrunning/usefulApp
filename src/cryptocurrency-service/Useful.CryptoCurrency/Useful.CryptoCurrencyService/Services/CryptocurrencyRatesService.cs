using Microsoft.Extensions.Logging;
using RestSharp;
using Useful.CryptoCurrencyCommon.Contracts;
using Useful.CryptoCurrencyService.Contracts;
using Useful.CryptoCurrencyService.Dto;

namespace Useful.CryptoCurrencyService.Services;

/// <summary>
///     Class for getting currency rates from coincap.io
/// </summary>
public sealed class CryptoCurrencyRatesService : BaseService, ICryptoCurrencyRatesService
{
    public CryptoCurrencyRatesService(ILogger<CryptoCurrencyRatesService> logger, ICryptoCurrencyGatewayConfiguration configuration) : base(logger, configuration)
    {
    }
    
    /// <inheritdoc cref="ICryptoCurrencyRatesService" />
    public async Task<IList<Data>?> GetAllCryptoCurrencyRatesAsync(CancellationToken token)
    {
        var url = new Uri($"{BaseUrl}");
        var client = new RestClient(SetOptions(url));

        var request = new RestRequest();
        var response = await client.ExecuteAsync(request, token);

        var listOfRates = GetContent<AllCurrencyRates>(response, url.AbsoluteUri);
        return listOfRates.Data;
    }
}