using AH.Company.Application.Interfaces;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.Company.Infrastructure;

public class StateManager(ILogger<StateManager> logger, DaprClient daprClient) : IStateManager
{
    public async Task SaveStateAsync(string store, string key, object value, CancellationToken cancellationToken)
    {   
        logger.LogInformation("Saving state to store - {Store} - {Key}", store, key);
        await daprClient.SaveStateAsync(store, key, value, cancellationToken: cancellationToken);
    }

    public async Task<T> GetStateAsync<T>(string store, string key, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting state from store - {Store} - {Key}", store, key);
        return await daprClient.GetStateAsync<T>(store, key,  cancellationToken:cancellationToken);
    }
    
    public async Task DeleteStateAsync(string store, string key, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting state from store - {Store} - {Key}", store, key);
        await daprClient.DeleteStateAsync(store, key, cancellationToken: cancellationToken);
    }
    
    public async Task<StateQueryResponse<T>> QueryStateAsync<T>(string store, string query, Dictionary<string, string> metadata, CancellationToken cancellationToken)
    {
        logger.LogInformation("Querying state from store - {Store} - {Query}", store, query);
        return await daprClient.QueryStateAsync<T>(store, query, metadata, cancellationToken: cancellationToken);
    }
}