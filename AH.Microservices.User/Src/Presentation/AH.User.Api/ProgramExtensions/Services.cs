using AH.User.Api.ProgramExtensions.Authorization;
using AH.User.Api.ProgramExtensions.Dapr;
using AH.User.Api.ProgramExtensions.HealthChecks;
using AH.User.Api.ProgramExtensions.LoggingAndTracing;
using AH.User.Api.ProgramExtensions.Swagger;

namespace AH.User.Api.ProgramExtensions; 

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
        builder.Services.RegisterDapr(builder.Configuration);
        builder.RegisterSwagger(appName, appTag);
        builder.RegisterAuth0();
        builder.AddCustomHealthChecks();
        
    
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