using Useful.ForecastService.Contracts;

namespace Useful.ForecastTaskScheduler;

public class ForecastDataUploader
{
    private readonly IOpenWeatherRestService _forecastService;

    public ForecastDataUploader(IOpenWeatherRestService forecastService)
    {
        _forecastService = forecastService;
    }

    public async Task UploadForecastData(CancellationToken token)
    {
        throw new NotImplementedException();
    }
}