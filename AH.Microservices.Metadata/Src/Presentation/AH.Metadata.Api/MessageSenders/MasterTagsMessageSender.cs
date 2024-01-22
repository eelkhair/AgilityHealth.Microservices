using System.Security.Claims;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application.Extensions;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Application.Queries.Domains;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Shared.V1.Events;
using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AutoMapper;
using MediatR;

namespace AH.Metadata.Api.MessageSenders;

/// <summary>
/// Class for sending messages related to master tags
/// </summary>
public class MasterTagsMessageSender : BaseMetadataMessageSender, IMasterTagsMessageSender
{
    /// <summary>
    /// Constructor for MasterTagCategoriesMessageSender
    /// </summary>
    /// <param name="sender">The message sender used to send messages to the pub/sub system</param>
    /// <param name="logger">The logger used to log information</param>
    /// <param name="mediator">The mediator used to send queries and commands</param>
    /// <param name="mapper">The mapper used to map objects</param>
    /// <returns></returns>
    public MasterTagsMessageSender(IMessageSender sender, ILogger<MasterTagsMessageSender> logger, IMediator mediator, IMapper mapper) : base(sender, logger, mediator, mapper)
    {
    }
    
    /// <summary>
    /// Send a message to create a master tag
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTag">The master tag to create</param>
    /// <returns></returns>
    public async Task SendCreateMasterTagMessageAsync(ClaimsPrincipal user,
        MasterTagWithCategoryAndParentTagResponse masterTag)
        => await SendMessage(user, masterTag, TopicNames.MasterTagCreate);
    
    /// <summary>
    /// Send a message to update a master tag 
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTag">The master tag to update</param>
    /// <returns></returns>
    public async Task SendUpdateMasterTagMessageAsync(ClaimsPrincipal user,
        MasterTagWithCategoryAndParentTagResponse masterTag)
        => await SendMessage(user, masterTag, TopicNames.MasterTagUpdate);
    
    /// <summary>
    /// Send a message to delete a master tag
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTag">The master tag</param>
    /// <returns></returns>
    public async Task SendDeleteMasterTagMessageAsync(ClaimsPrincipal user,
        MasterTagWithCategoryAndParentTagResponse masterTag)
        => await SendMessage(user, masterTag, TopicNames.MasterTagDelete);
    

    private async Task SendMessage(ClaimsPrincipal user, MasterTagWithCategoryAndParentTagResponse masterTag, string eventType)
    {
        var domains = await Mediator.Send(new ListDomainsQuery(user, Logger));

        foreach (var dto in domains.Select(domain => new MasterTagEventDto
                 {
                     Domain = domain.Name, MasterTag = masterTag
                 }))
        {
            await MessageSender.SendEventAsync(eventType, user.GetUserId(), dto);
        }
    }

    
}