using AH.Microservices.HealthChecks.Dtos;

namespace AH.Microservices.HealthChecks;

public class DaprSecretStoreHealthCheck : IHealthCheck
{
    private readonly DaprClient _daprClient;
    private readonly SecretStoreOptions _secretStoreOptions;

    public DaprSecretStoreHealthCheck(DaprClient daprClient, SecretStoreOptions secretStoreOptions)
    {
        _daprClient = daprClient;
        _secretStoreOptions = secretStoreOptions;
    }

    public string Name => typeof(DaprSecretStoreHealthCheck).Name;
    protected string SecretStoreName => _secretStoreOptions.StoreName;

    
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var secret = await _daprClient.GetBulkSecretAsync(storeName: SecretStoreName, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (secret is null) return new HealthCheckResult(context.Registration.FailureStatus, $"Dapr secret store :{SecretStoreName} is unhealthy.");
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, $"Dapr secret store :{SecretStoreName} is unhealthy. Exception: {ex.Message}");
        }

        return HealthCheckResult.Healthy($"Dapr secret store: {SecretStoreName} is healthy.");
    }
}