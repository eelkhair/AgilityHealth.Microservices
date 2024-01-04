using System.Diagnostics.CodeAnalysis;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.User.Infrastructure;
[ExcludeFromCodeCoverage]
public class DaprUtility(ILogger<DaprUtility> logger, DaprClient daprClient) : IDaprUtility
{
    public async Task SendEventAsync(string pubSubName, string topic, string userId, string message)
    { 
        var messageInfo = new {pubSubName, topic, userId, message};
        try
        {
            var eventModel = new EventDto(userId, message);
            await daprClient.PublishEventAsync(pubSubName, topic, eventModel);
           
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
}