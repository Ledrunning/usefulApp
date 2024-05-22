using Useful.ForecastRepository;
using Useful.ForecastService;
using Useful.ForecastService.Contracts;

namespace Useful.ForecastTaskScheduler;

public class ForecastDataUploader
{
    private readonly ICosmosDbContext _dbContext;
    private readonly IOpenWeatherRestService _forecastService;

    public ForecastDataUploader(IOpenWeatherRestService forecastService, ICosmosDbContext dbContext)
    {
        _forecastService = forecastService;
        _dbContext = dbContext;
    }

    public async Task UploadForecastData(string city, CancellationToken token)
    {
        var result = await _forecastService.GetWeatherFromOpenWeatherApi(city, token);

        if (result.Main != null)
        {
            await _dbContext.InsertDataAsync(WeatherMapper.MapToWeather(result.Main));
        }
    }
}