using Useful.ForecastDomain.Entities;
using Useful.ForecastRepository;
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

    //TODO: think about it
    public async Task UploadForecastData(CancellationToken token)
    {
        var result = await _forecastService.GetWeatherFromOpenWeatherApi("Berlin", token);
        await _dbContext.InsertDataAsync(new Weather()
        {

        });
    }
}