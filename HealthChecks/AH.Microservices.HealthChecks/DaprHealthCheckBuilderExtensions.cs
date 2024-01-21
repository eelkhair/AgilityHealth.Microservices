using Microsoft.Extensions.DependencyInjection;

namespace AH.Microservices.HealthChecks;

public static class DaprHealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder AddDapr(this IHealthChecksBuilder builder) =>
        builder.AddCheck<DaprHealthCheck>("dapr");
}
