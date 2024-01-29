using AH.Microservices.HealthChecks.Dtos;

namespace AH.Microservices.HealthChecks;

public class DaprStateStoreHealthCheck : IHealthCheck
{
    private readonly DaprClient _daprClient;
    protected readonly StateStoreOptions _stateStoreOptions;

    public DaprStateStoreHealthCheck(DaprClient daprClient, StateStoreOptions stateStoreOptions)
    {
        _daprClient = daprClient;
        _stateStoreOptions = stateStoreOptions;
    }

    public virtual string Name => typeof(DaprStateStoreHealthCheck).Name;
    protected virtual string StateStoreName => _stateStoreOptions.StoreName;
    
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await _daprClient.SaveStateAsync(storeName: StateStoreName, key: "healthCheck", value: new { healthCheck = true }, cancellationToken: cancellationToken);
            await _daprClient.GetStateAsync<object>(storeName: StateStoreName, key: "healthCheck", cancellationToken: cancellationToken);
            await _daprClient.DeleteStateAsync(storeName: StateStoreName, key: "healthCheck", cancellationToken: cancellationToken);
            return HealthCheckResult.Healthy($"Dapr state store: {StateStoreName} is healthy.");
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, $"Dapr state store: {StateStoreName} is unhealthy. Error: {ex.Message}");
        }
    }
}