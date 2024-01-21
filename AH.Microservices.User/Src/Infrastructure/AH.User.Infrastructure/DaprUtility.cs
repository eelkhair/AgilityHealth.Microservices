using System.Diagnostics.CodeAnalysis;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using AH.User.Domain.Constants;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.User.Infrastructure;
[ExcludeFromCodeCoverage]
public class DaprUtility(ILogger<DaprUtility> logger, DaprClient daprClient) : IDaprUtility
{
    public async Task SendEventAsync<T>(string topic, string userId, T message)
    { 
        var messageInfo = new {topic, userId, message};
        try
        {
            var eventModel = new EventDto<T>(userId, message);
            await daprClient.PublishEventAsync(PubSubNames.RabbitMq, topic, eventModel);
           
            logger.LogInformation("Event sent - {MessageInfo}", messageInfo);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error sending event - {MessageInfo}", messageInfo);
        }
    }
    
    public async Task<Dictionary<string,Dictionary<string, string>>> GetSecretsAsync(string store)
    { 
        
        try
        {
            return await daprClient.GetBulkSecretAsync(store);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error retrieving secret - {Store}", store);
            return new Dictionary<string, Dictionary<string, string>>();
        }
    }

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
}