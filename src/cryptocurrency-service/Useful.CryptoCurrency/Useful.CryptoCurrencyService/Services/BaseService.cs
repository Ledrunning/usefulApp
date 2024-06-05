using System.Text.Json;
using Microsoft.Extensions.Logging;
using RestSharp;
using Useful.CryptoCurrencyCommon.Exceptions;

namespace Useful.CryptoCurrencyService.Services;

public class BaseService
{
    protected readonly string BaseUrl;
    private readonly ILogger logger;
    private readonly int timeout;

    public BaseService(ILogger<BaseService> logger, string baseUrl, int timeout)
    {
        this.logger = logger;
        BaseUrl = baseUrl;
        this.timeout = timeout;
    }

    protected T GetContent<T>(RestResponseBase response, string url)
    {
        if (response.IsSuccessful)
        {
            if (response.Content != null)
            {
                var model = JsonSerializer.Deserialize<T>(response.Content);
                logger.LogInformation("Request for Coincap successfully finished {Url}", url);
                if (model != null)
                {
                    return model;
                }
                logger.LogInformation("Requested data from Coincap is null {Url}", url);
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
            Timeout = TimeSpan.FromMilliseconds(timeout)
        };
    }
}