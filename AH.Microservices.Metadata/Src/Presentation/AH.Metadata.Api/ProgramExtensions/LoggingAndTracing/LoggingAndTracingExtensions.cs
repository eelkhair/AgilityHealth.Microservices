using System.Diagnostics;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.OpenTelemetry;

namespace AH.Metadata.Api.ProgramExtensions.LoggingAndTracing;

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
            .WriteTo.Seq(seqServerUrl!)
            .Enrich.WithProperty("ApplicationName", appTag)
            .Enrich.WithOpenTelemetryTraceId()
            .Enrich.WithOpenTelemetrySpanId()
            .Filter.ByExcluding(LogFilter.Exclude )
            .CreateLogger();

        builder.Host.UseSerilog();
    }
    
    private static void ConfigureTracing(this WebApplicationBuilder builder, string appTag)
    {
        builder.Services.AddApplicationInsightsTelemetry();
        builder.Services.AddSingleton(new ActivitySource(appTag));
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(appTag, appTag, "1.0.0"))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation(c=>c.FilterHttpRequestMessage = (httpRequestMessage) =>
                {
                    if (httpRequestMessage.RequestUri!.Host.StartsWith("seq"))
                    {
                        return false;
                    }

                    return true;
                })
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