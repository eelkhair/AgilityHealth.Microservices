using AH.Company.Domain.Constants;
using AH.Microservices.HealthChecks;
using AH.Microservices.HealthChecks.Dtos;
using Dapr.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AH.Company.Api.ProgramExtensions.HealthChecks;

internal static class HealthCheckExtensions
{
    public static void AddCustomHealthChecks(this WebApplicationBuilder builder)
    {
        var stateStore = new StateStoreOptions()
        {
            StoreName = StateStores.Redis
        };
        builder.Services.AddSingleton(sp => new DaprStateStoreHealthCheck(new DaprClientBuilder().Build(), stateStore));
       
        var secretStore = new SecretStoreOptions
        {
            StoreName = SecretStoreNames.Local
        };
        builder.Services.AddSingleton(sp => new DaprSecretStoreHealthCheck(new DaprClientBuilder().Build(), secretStore));

        var pubSub = new DistributedEventBusOptions
        {
            Prefix = string.Empty,
            Postfix = string.Empty,
            PubSubName = PubSubNames.RabbitMq
        };
        
        builder.Services.AddSingleton(sp => new DaprPubSubHealthCheck(new DaprClientBuilder().Build(), pubSub));
        builder.Services
            .AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddDapr();
    }
}