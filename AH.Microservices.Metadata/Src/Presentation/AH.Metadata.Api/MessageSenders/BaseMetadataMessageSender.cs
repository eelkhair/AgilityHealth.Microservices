using System.Diagnostics.CodeAnalysis;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AH.Metadata.Api.MessageSenders;

/// <summary>
/// Base class for all message senders in the Metadata API
/// </summary>

[ExcludeFromCodeCoverage]
public abstract class BaseMetadataMessageSender
{
    /// <summary>
    /// The message sender used to send messages to the pub/sub system
    /// </summary>
    protected IMessageSender MessageSender { get; }
    
    /// <summary>
    /// The mediator used to send queries and commands
    /// </summary>
    protected IMediator Mediator { get; }
    
    /// <summary>
    /// The logger used to log information
    /// </summary>
    protected ILogger Logger { get; }
    
    /// <summary>
    /// The mapper used to map objects
    /// </summary>
    protected IMapper Mapper { get; }

    /// <summary>
    /// Constructor for BaseMetadataMessageSender
    /// </summary>
    /// <param name="sender">The message sender used to send messages to the pub/sub system</param>
    /// <param name="logger">The logger used to log information</param>
    /// <param name="mediator">The mediator used to send queries and commands</param>
    /// <param name="mapper">The mapper used to map objects</param>
    protected BaseMetadataMessageSender(IMessageSender sender, ILogger logger, IMediator mediator, IMapper mapper)
    {
        MessageSender = sender;
        Mediator = mediator;
        Logger = logger;
        Mapper = mapper;
    }
}