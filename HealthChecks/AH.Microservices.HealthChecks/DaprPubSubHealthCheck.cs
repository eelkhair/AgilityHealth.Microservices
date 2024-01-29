using AH.Microservices.HealthChecks.Dtos;

namespace AH.Microservices.HealthChecks;

public class DaprPubSubHealthCheck : IHealthCheck
{
    private readonly DaprClient _daprClient;
    protected readonly DistributedEventBusOptions _distributedEventBusOptions;

    public DaprPubSubHealthCheck(DaprClient daprClient, DistributedEventBusOptions distributedEventBusOptions)
    {
        _daprClient = daprClient;
        _distributedEventBusOptions = distributedEventBusOptions;
    }

    public virtual string Name => typeof(DaprPubSubHealthCheck).Name;
    protected virtual string PubSubName => _distributedEventBusOptions.PubSubName;

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var topicName = $"{_distributedEventBusOptions.Prefix}{"healthCheckTopic"}";
            var ttl = 60;
            
            await _daprClient.PublishEventAsync(_distributedEventBusOptions.PubSubName, topicName, new { }, new Dictionary<string, string>()
            {
                {"ttlInSeconds", ttl.ToString()}
            }, cancellationToken: cancellationToken);
            

            return HealthCheckResult.Healthy($"Dapr pubsub: {PubSubName} for topic '{topicName}' is healthy.");
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, $"Dapr pubsub: {PubSubName} is unhealthy. Error: {ex.Message}");
        }
    }
}