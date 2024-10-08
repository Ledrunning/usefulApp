using System.Diagnostics;
using NLog;
using NLog.Extensions.Logging;
using Useful.CryptoCurrencyGateway.Configuration;
using Useful.CryptoCurrencyService.Contracts;
using Useful.CryptoCurrencyService.Services;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

const string LoggerConfig = "NLog.config";
var logger = LogManager.GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Logging.ClearProviders().SetMinimumLevel(LogLevel.Debug).AddNLog(LoggerConfig);

    builder.Services.Configure<ConcapApiConfiguration>(
        builder.Configuration.GetSection(ConcapApiConfiguration.SectionName));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddLogging();

    builder.Services.AddTransient<ICryptoCurrencyRatesService, CryptoCurrencyRatesService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoCurrencyAPI v1"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    var name = typeof(Program).Assembly.GetName().Name;
    Trace.Write(
        $"[{DateTime.Now:HH:mm:ss.fff}] Application startup error [{name}]! Details {e.Message}");
    logger.Fatal(e, $"Application startup error [{name}]");
}
finally
{
    LogManager.Shutdown();
}