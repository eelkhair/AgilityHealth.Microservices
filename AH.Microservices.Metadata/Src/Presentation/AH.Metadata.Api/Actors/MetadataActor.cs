using System.Security.Claims;
using AH.Metadata.Application.Queries.Domains;
using AH.Metadata.Shared.V1.ActorInterfaces;
using AH.Metadata.Shared.V1.Models.Responses;
using AH.Shared.Application.Interfaces;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr.Actors.Runtime;
using MediatR;

namespace AH.Metadata.Api.Actors;

/// <summary>
/// 
/// </summary>
public class MetadataActor : Actor, IMetadataActor
{
    private readonly IMapper _mapper;
    private readonly ILogger<MetadataActor> _logger;
    private readonly IMediator _mediator;
    private readonly IMessageSender _messageSender;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="logger"></param>
    /// <param name="provider"></param>
    /// <param name="messageSender"></param>
    public MetadataActor(ActorHost host, ILogger<MetadataActor> logger, IServiceProvider provider, IMessageSender messageSender) : base(host)
    {
        _mapper = provider.GetRequiredService<IMapper>();
        _logger = logger;
        _mediator = provider.GetRequiredService<IMediator>();
        _messageSender = messageSender;
      
    }

    /// <summary>
    /// Gets a domain by its unique identifier
    /// </summary>
    /// <param name="domainUId"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<DomainResponse> GetDomain(Guid domainUId, string user)
    {
        _logger.LogInformation("received request for domain {DomainUId} from user {User}", domainUId, user);
        var query = new GetDomainQuery(new ClaimsPrincipal(), _logger, domainUId);
        var result = await _mediator.Send(query);
        return _mapper.Map<DomainResponse>(result);
    }

    /// <summary>
    /// Sends a pub-sub message
    /// </summary>
    /// <param name="message"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> SendMessage(string message, string userId)
    {
        try
        {
            await _messageSender.SendEventAsync(PubSubNames.Redis, TopicNames.Metadata, userId, new { Message = message});
            return "Message sent";
        }
        catch (Exception)
        {
            return "Message not sent";
        }
    }
}