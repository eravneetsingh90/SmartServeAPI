using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using SmartServe.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region Serilog Configuration (Production Ready)

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        // Base level
        .MinimumLevel.Information()

        // 🔥 Suppress ASP.NET Core internal logs
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
        .MinimumLevel.Override("System", LogEventLevel.Error)

        // Enrichers
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "SmartServe.API")
        //.Enrich.WithEnvironmentName()

        // Console (for container / dev visibility)
        .WriteTo.Console()

        // Rolling file logs
        .WriteTo.File(
            path: "logs/smartserve-.log",
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 30,
            restrictedToMinimumLevel: LogEventLevel.Information)

        // Elasticsearch sink
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
        {
            AutoRegisterTemplate = true,
            IndexFormat = "smartserve-logs",
            MinimumLogEventLevel = LogEventLevel.Information
        });
});

#endregion

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseSerilogRequestLogging();
//app.UseSerilogRequestLogging(options =>
//{
//    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
//    {
//        diagnosticContext.Set("Action", httpContext.Request.Path);
//        diagnosticContext.Set("StatusCode", httpContext.Response.StatusCode);
//        diagnosticContext.Set("Method", httpContext.Request.Method);
//    };
//});

app.UseMiddleware<SingleLogMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

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
