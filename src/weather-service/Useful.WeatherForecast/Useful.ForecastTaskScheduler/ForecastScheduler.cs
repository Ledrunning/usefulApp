using Hangfire;

namespace Useful.ForecastTaskScheduler
{
    public class ForecastScheduler
    {
        //"0 */2 * * * *" - 2 min. cron expression for debugging 
        // "0 */12 * * *" - 12 hours
        public void ScheduleForecastDataUpdate(CancellationToken token)
        {
            // Update every 12 hours
            RecurringJob.AddOrUpdate<ForecastDataUploader>(nameof(ForecastDataUploader), updater => updater.UploadForecastData(token), "0 */12 * * *");
        }
    }
}
