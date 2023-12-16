using System.Reflection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.OpenTelemetry;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace AH.Web.Settings;

public static class LogConfiguration
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .Enrich.WithExceptionDetails()
            .Enrich.WithOpenTelemetryTraceId()
            .Enrich.WithOpenTelemetrySpanId()
            .WriteTo.Elasticsearch(ConfigureElasticSink(builder.Configuration, builder.Environment.EnvironmentName))
            .Enrich.WithProperty("Environment", builder.Environment)
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.SetupTracing("AH.Web");
        
    }
    
    static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
    {
        return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"] ?? string.Empty))
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{Assembly.GetEntryAssembly()?.GetName().Name?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
        };
    }

    private static void SetupTracing(this WebApplicationBuilder webApplicationBuilder, string serviceName)
    {
        webApplicationBuilder.Logging.AddOpenTelemetry(options =>
        {
            options
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName));
        });
     
        webApplicationBuilder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(serviceName, $"AH.{serviceName}", "1.0.0"))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddSqlClientInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter(x=>
                {
                    x.Endpoint = new Uri("http://192.168.1.160:4317");
                })
                .AddZipkinExporter())
            .WithMetrics(metrics => metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                //          .AddConsoleExporter()
            );
    }
}