﻿using AH.Company.Api.ProgramExtensions.Authorization;
using AH.Company.Api.ProgramExtensions.Dapr;
using AH.Company.Api.ProgramExtensions.HealthChecks;
using AH.Company.Api.ProgramExtensions.LoggingAndTracing;
using AH.Company.Api.ProgramExtensions.Swagger;

namespace AH.Company.Api.ProgramExtensions; 

/// <summary>
/// Extension methods for IServiceCollection
/// </summary>
public static class Services
{
    /// <summary>
    /// Register methods
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="appName"></param>
    /// <param name="appTag"></param>
    public static void ConfigureServices(this WebApplicationBuilder builder, string appName, string appTag)
    {
        builder.RegisterSwagger(appName, appTag);
        builder.RegisterAuth0();
        builder.AddCustomHealthChecks();
        builder.Services.RegisterDapr();
    
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("_myAllowSpecificOrigins",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5010")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });   
        
        builder.ConfigureLoggingAndTracing(appTag);
    }
}