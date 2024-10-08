using System.Text.Json;
using Microsoft.Extensions.Logging;
using RestSharp;
using Useful.CryptoCurrencyCommon.Contracts;
using Useful.CryptoCurrencyCommon.Exceptions;

namespace Useful.CryptoCurrencyService.Services;

public class BaseService
{
    private readonly ILogger<BaseService> _logger;
    private readonly int? _timeout;
    protected readonly string? BaseUrl;

    public BaseService(ILogger<BaseService> logger, ICryptoCurrencyGatewayConfiguration configuration)
    {
        _logger = logger;
        BaseUrl = configuration.BaseUrl;
        _timeout = configuration.Timeout;
    }

    protected T GetContent<T>(RestResponseBase response, string url)
    {
        if (response.IsSuccessful)
        {
            if (response.Content != null)
            {
                var model = JsonSerializer.Deserialize<T>(response.Content);
                _logger.LogInformation("Request for Coincap successfully finished {Url}", url);
                if (model != null)
                {
                    return model;
                }

                _logger.LogInformation("Requested data from Coincap is null {Url}", url);
            }
        }

        throw new CryptoCurrencyRatesException(
            $"Response from Concap failed. Status code: {response.StatusCode}, {response.ErrorMessage}");
    }

    protected RestClientOptions SetOptions(Uri url)
    {
        return new RestClientOptions(url)
        {
            ThrowOnAnyError = true,
            Timeout = TimeSpan.FromMilliseconds(_timeout.GetValueOrDefault())
        };
    }
}