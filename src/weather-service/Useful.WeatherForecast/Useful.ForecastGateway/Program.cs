using Hangfire;
using Useful.ForecastGateway.Extension;
using Useful.ForecastGateway.Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSettings(builder.Configuration);
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureServices();

builder.ConfigureHangFire(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherForecastAPI v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHangfireDashboard("/taskboard", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();