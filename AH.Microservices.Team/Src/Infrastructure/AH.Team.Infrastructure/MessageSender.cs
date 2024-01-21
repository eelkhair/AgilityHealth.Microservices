using System.Diagnostics.CodeAnalysis;
using AH.Team.Application.Dtos;
using AH.Team.Application.Interfaces;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.Team.Infrastructure;
[ExcludeFromCodeCoverage]
public class MessageSender(ILogger<MessageSender> logger, DaprClient daprClient) : IMessageSender
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
}