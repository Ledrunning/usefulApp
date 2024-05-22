using Hangfire;
using Useful.ForecastService.Contracts;

namespace Useful.ForecastTaskScheduler;

public class ForecastScheduler
{
    private readonly IOpenWeatherRestService _openWeatherRestService;

    //"0 */2 * * * *" - 2 min. cron expression for debugging 
    // "0 */12 * * *" - 12 hours
    public ForecastScheduler(IOpenWeatherRestService openWeatherRestService)
    {
        _openWeatherRestService = openWeatherRestService;
    }

    public void ScheduleForecastDataUpdate(CancellationToken token)
    {
        // Update every 12 hours
        RecurringJob.AddOrUpdate<ForecastDataUploader>(nameof(ForecastDataUploader),
            updater => updater.UploadForecastData(_openWeatherRestService.Location, token), "0 */12 * * *");
    }
}