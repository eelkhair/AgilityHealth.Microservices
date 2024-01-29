using AH.Microservices.HealthChecks;
using AH.Microservices.HealthChecks.Dtos;
using AH.Team.Domain.Constants;
using Dapr.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AH.Team.Api.ProgramExtensions.HealthChecks;

internal static class HealthCheckExtensions
{
    public static void AddCustomHealthChecks(this WebApplicationBuilder builder)
    {
        var stateStore = new StateStoreOptions()
        {
            StoreName = StateStores.Redis
        };
        builder.Services.AddSingleton(_ => new DaprStateStoreHealthCheck(new DaprClientBuilder().Build(), stateStore));
       
        var secretStore = new SecretStoreOptions
        {
            StoreName = SecretStoreNames.Local
        };
        builder.Services.AddSingleton(_ => new DaprSecretStoreHealthCheck(new DaprClientBuilder().Build(), secretStore));

        var pubSub = new DistributedEventBusOptions
        {
            Prefix = string.Empty,
            Postfix = string.Empty,
            PubSubName = PubSubNames.RabbitMq
        };
        
        builder.Services.AddSingleton(_ => new DaprPubSubHealthCheck(new DaprClientBuilder().Build(), pubSub));
        builder.Services
            .AddHealthChecks()
            .AddDapr()
            .AddCheck("self", () => HealthCheckResult.Healthy());
    }
}