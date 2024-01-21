
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace AH.Microservices.HealthChecks;

public static class HealthCheckEndpointRouteBuilderExtensions
{
    public static void MapCustomHealthChecks(
        this WebApplication app,
        string healthPattern = "/healthzEndpoint",
        string livenessPattern = "/liveness",
        Func<Microsoft.AspNetCore.Http.HttpContext, HealthReport, Task> responseWriter = default)
    {
        app.MapHealthChecks(healthPattern, new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = responseWriter,


        });
        app.MapHealthChecks(livenessPattern, new HealthCheckOptions
        {
            Predicate = r => r.Name.Contains("self")
        });
    }
}
