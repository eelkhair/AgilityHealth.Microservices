using System.Diagnostics;
using System.Reflection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.OpenTelemetry;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace AH.Team.Api.ProgramExtensions.LoggingAndTracing;

internal static class LoggingAndTracingExtensions
{
    public static void ConfigureLoggingAndTracing(this WebApplicationBuilder builder, string appTag)
    {
        builder.ConfigureLogging(appTag);
        builder.ConfigureTracing(appTag);
    }
    private static void ConfigureLogging(this WebApplicationBuilder builder, string appTag)
    {
        var seqServerUrl = builder.Configuration["SeqServerUrl"];

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("ApplicationName", appTag)
            .Enrich.WithOpenTelemetryTraceId()
            .Enrich.WithOpenTelemetrySpanId()
            .Filter.ByExcluding(LogFilter.Exclude )
            .WriteTo.Elasticsearch(ConfigureElasticSink(builder.Configuration, builder.Environment.EnvironmentName))
            .WriteTo.Seq(seqServerUrl!)
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();
    }
    static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
    {
        return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"] ?? string.Empty))
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{Assembly.GetEntryAssembly()?.GetName().Name?.ToLower().Replace(".", "-")}-{environment.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
        };
    }
    private static void ConfigureTracing(this WebApplicationBuilder builder, string appTag)
    {
        builder.Services.AddApplicationInsightsTelemetry();
        builder.Services.AddSingleton(new ActivitySource(appTag));
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(appTag, appTag, "1.0.0"))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation(
                    options =>
                    {
                        options.Filter = (httpContext) => 
                            !httpContext.Request.Path.Value!.Contains("healthz", StringComparison.InvariantCultureIgnoreCase);
                    })
                .AddHttpClientInstrumentation(c=>
                    c.FilterHttpRequestMessage = httpRequestMessage => 
                    !httpRequestMessage.RequestUri!.Host.StartsWith("seq")  &&
                    !httpRequestMessage.RequestUri.ToString().Contains("healthz", StringComparison.InvariantCultureIgnoreCase)
                    && !httpRequestMessage.RequestUri.Authority.StartsWith("192.168.1.160:9200"))
                .AddZipkinExporter()
                .AddOtlpExporter(x=>
                {
                    x.Endpoint = new Uri("http://192.168.1.160:4317");
                })
                .AddEntityFrameworkCoreInstrumentation(c=>
                {
                    c.SetDbStatementForText = true;
                })
            )
            .WithMetrics(metrics => metrics
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(x =>
                {
                    x.Endpoint = new Uri("http://192.168.1.160:4317"); 
                })
            );
    }
}