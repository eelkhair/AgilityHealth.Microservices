using AH.Shared.Application.Dtos;
using AH.Shared.Application.Interfaces;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.Shared.Infrastructure;

public class MessageSender : IMessageSender
{
    private readonly ILogger<MessageSender> _logger;
    private readonly DaprClient _daprClient;
    
    public MessageSender(ILogger<MessageSender> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }
    
    public async Task SendEventAsync<T>(string pubSubName, string topic, string userId, T data)
    {
        try
        {
            _logger.LogInformation("Sending event {PubSubName} {Topic} {UserId} {Data}", pubSubName, topic, userId, data);
            var eventModel = new EventDto(userId, data);
            await _daprClient.PublishEventAsync(pubSubName, topic, eventModel);
           
            _logger.LogInformation("Event sent {PubSubName} {Topic} {UserId} {Data}", pubSubName, topic, userId, data);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error sending event {PubSubName} {Topic} {UserId} {Data}", pubSubName, topic, userId, data);
        }
    }
}