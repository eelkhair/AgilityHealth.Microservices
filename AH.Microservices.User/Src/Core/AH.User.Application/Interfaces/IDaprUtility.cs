namespace AH.User.Application.Interfaces;

public interface IDaprUtility
{
    Task SendEventAsync<T>(string topic, string userId, T message);
    Task<Dictionary<string,Dictionary<string, string>>> GetSecretsAsync(string store);
    Task SaveStateAsync(string store, string key, object value, CancellationToken cancellationToken);
    Task<T> GetStateAsync<T>(string store, string key, CancellationToken none);
}