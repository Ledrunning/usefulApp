using Hangfire.Dashboard;

namespace Useful.ForecastGateway.Hangfire;

//TODO Maybe use auth
public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        // for everyone!
        return true;
    }
}