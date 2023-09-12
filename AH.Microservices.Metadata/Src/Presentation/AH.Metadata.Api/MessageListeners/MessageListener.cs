using System.Text.Json;
using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;

namespace AH.Metadata.Api.MessageListeners;

/// <inheritdoc />
public class MessageListener : BaseMessageListener
{
    /// <inheritdoc />
    public MessageListener(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    /// <summary>
    /// Handles a message from the pubsub
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [Topic(PubSubNames.Redis, TopicNames.Metadata)]
    public Task HandleMessage(EventDto message )
    {
        Logger.LogInformation("Received message {Message}", JsonSerializer.Serialize(message));
        return Task.CompletedTask;
    }
}