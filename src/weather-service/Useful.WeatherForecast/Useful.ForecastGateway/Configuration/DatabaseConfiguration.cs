using Useful.ForecastCommon.Contract;

namespace Useful.ForecastGateway.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public static readonly string Configuration = "DatabaseConfiguration";
        public string? DbConnectionString { get; set; }
        public string? DbName { get; set; }
    }
}