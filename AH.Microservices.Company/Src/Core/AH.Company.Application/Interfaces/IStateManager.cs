using Dapr.Client;

namespace AH.Company.Application.Interfaces;

public interface IStateManager
{
    Task SaveStateAsync(string store, string key, object value, CancellationToken cancellationToken);
    Task<T> GetStateAsync<T>(string store, string key, CancellationToken cancellationToken);
    Task DeleteStateAsync(string store, string key, CancellationToken cancellationToken);
    Task<StateQueryResponse<T>> QueryStateAsync<T>(string store, string query, Dictionary<string, string> metadata,
        CancellationToken cancellationToken);
}