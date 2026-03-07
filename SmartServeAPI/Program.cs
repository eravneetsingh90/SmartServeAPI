using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using SmartServe.API.Dependencies;
using SmartServe.Infrastructure.Authentication;
using SmartServe.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region Logging (Serilog)

builder.Host.UseSerilog((context, services, config) =>
{
    config
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
        .MinimumLevel.Override("System", LogEventLevel.Error)

        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", context.Configuration["ApiUniqueName"])

        .WriteTo.Console()

        .WriteTo.File(
            path: "logs/smartserve-.log",
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 30,
            restrictedToMinimumLevel: LogEventLevel.Information)

        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
            new Uri(context.Configuration["ElasticConfiguration:Uri"]))
        {
            AutoRegisterTemplate = true,
            IndexFormat = "smartserve-logs-{0:yyyy.MM}",
            MinimumLogEventLevel = LogEventLevel.Information
        });
});

#endregion

#region Services

builder.Services.UseApi(builder.Configuration);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication(builder.Configuration);

#endregion

var app = builder.Build();

#region Middleware Pipeline

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global logging (first)
app.UseMiddleware<SingleLogMiddleware>();

// Tenant resolution
app.UseMiddleware<TenantMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

#region Application Start

try
{
    Log.Information("Starting SmartServe API...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}

#endregion