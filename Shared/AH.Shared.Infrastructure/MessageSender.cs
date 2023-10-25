using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using AH.Shared.Application.Dtos;
using AH.Shared.Application.Interfaces;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace AH.Shared.Infrastructure;
[ExcludeFromCodeCoverage]
public class MessageSender : IMessageSender
{
    private readonly ILogger<MessageSender> _logger;
    private readonly DaprClient _daprClient;
    
    public MessageSender(ILogger<MessageSender> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }
    
    public async Task SendEventAsync(string pubSubName, string topic, string userId, string message)
    { 
        var messageInfo = new {pubSubName, topic, userId, message};
        try
        {
            var eventModel = new EventDto(userId, message);
            await _daprClient.PublishEventAsync(pubSubName, topic, eventModel);
           
            _logger.LogInformation("Event sent - {MessageInfo}", messageInfo);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error sending event - {MessageInfo}", messageInfo);
        }
    }
}