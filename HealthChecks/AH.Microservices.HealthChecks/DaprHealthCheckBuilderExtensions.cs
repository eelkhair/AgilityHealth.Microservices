using Microsoft.Extensions.DependencyInjection;

namespace AH.Microservices.HealthChecks;

public static class DaprHealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder AddDapr(this IHealthChecksBuilder builder)
    {
       builder.AddCheck<DaprHealthCheck>("dapr");
       builder.AddCheck<DaprStateStoreHealthCheck>("state store");
       builder.AddCheck<DaprSecretStoreHealthCheck>("secret store");
       builder.AddCheck<DaprPubSubHealthCheck>("pub sub");
       return builder;
    }
        
}
