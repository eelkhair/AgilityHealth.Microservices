using System.Diagnostics;
using System.Net;
using System.Reflection;
using AH.Shared.Api.Authorization;
using AH.Shared.Api.Dapr;
using AH.Shared.Api.Dtos;
using AH.Shared.Api.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.OpenTelemetry;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace AH.Shared.Api; 
public static class Services
{
    public static void Build(this IServiceCollection services, SwaggerDocSetup swagger, Auth0Configuration auth0Config,
        string environment, IConfiguration configuration, ConfigureHostBuilder host)
    {
        
        ConfigureLogging(environment, configuration);
        services.RegisterSwagger(swagger, auth0Config);
        services.RegisterAuth0(auth0Config, swagger);
        services.RegisterDapr();
        services.AddApplicationInsightsTelemetry();
        services.AddSingleton(new ActivitySource(swagger.AppTag));
        
        services.AddCors(options =>
        {
            options.AddPolicy( "_myAllowSpecificOrigins",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5010")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        host.UseSerilog();
    }
    
    static void ConfigureLogging(string environment, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithOpenTelemetryTraceId()
            .Enrich.WithOpenTelemetrySpanId()
            .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
            .Enrich.WithProperty("Environment", environment)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }

    static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
    {
        return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"] ?? string.Empty))
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{Assembly.GetEntryAssembly()?.GetName().Name?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
        };
    }
    
    public static void SetupTracing(this WebApplicationBuilder webApplicationBuilder, string serviceName)
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