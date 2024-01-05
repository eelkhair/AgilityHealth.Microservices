namespace AH.User.Application.Interfaces;

public interface IDaprUtility
{
    Task SendEventAsync(string pubSubName, string topic, string userId, string message);
    Task<Dictionary<string,Dictionary<string, string>>> GetSecretsAsync(string store);
    Task SaveStateAsync(string store, string key, object value, CancellationToken cancellationToken);
}