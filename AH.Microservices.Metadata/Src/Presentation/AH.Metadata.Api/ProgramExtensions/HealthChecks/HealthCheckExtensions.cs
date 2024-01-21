using AH.Microservices.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AH.Metadata.Api.ProgramExtensions.HealthChecks;

internal static class HealthCheckExtensions
{
    public static void AddCustomHealthChecks(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddDapr();
    }
}