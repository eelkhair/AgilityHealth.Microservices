using System.Diagnostics.CodeAnalysis;
using AH.Team.Application.Dtos;
using AH.Team.Application.Interfaces;
using AH.Team.Domain.Constants;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.Team.Infrastructure;
[ExcludeFromCodeCoverage]
public class MessageSender(ILogger<MessageSender> logger, DaprClient daprClient) : IMessageSender
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
}