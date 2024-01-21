using AutoMapper;
using MediatR;

namespace AH.Metadata.Api.MessageListeners;

/// <inheritdoc />
public class MessageListener : BaseMessageListener
{
    /// <inheritdoc />
    public MessageListener(IMapper mapper, ILogger<MessageListener> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }

}