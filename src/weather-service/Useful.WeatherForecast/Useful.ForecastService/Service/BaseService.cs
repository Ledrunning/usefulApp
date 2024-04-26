using Newtonsoft.Json;
using RestSharp;
using Useful.ForecastCommon.Exception;

namespace Useful.ForecastService.Service;

public class BaseService
{
    private readonly int _timeout;
    protected readonly string BaseUrl;

    public BaseService(string baseUrl, int timeout)
    {
        BaseUrl = baseUrl;
        _timeout = timeout;
    }

    protected T GetContent<T>(RestResponseBase response, string url)
    {
        if (response.IsSuccessful)
        {
            if (response.Content != null)
            {
                var model = JsonConvert.DeserializeObject<T>(response.Content);
                if (model != null)
                {
                    return model;
                }
            }
        }

        throw new WeatherForecastException(
            $"Response from OpenWeather failed. Status code: {response.StatusCode}, {response.ErrorMessage}");
    }

    protected RestClientOptions SetOptions(Uri url)
    {
        return new RestClientOptions(url)
        {
            ThrowOnAnyError = true,
            MaxTimeout = _timeout
        };
    }
}