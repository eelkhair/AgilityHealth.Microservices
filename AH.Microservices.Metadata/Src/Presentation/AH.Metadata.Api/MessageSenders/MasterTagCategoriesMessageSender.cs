﻿using System.Security.Claims;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Extensions;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Application.Queries.Domains;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Shared.V1.Events;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AutoMapper;
using MediatR;

namespace AH.Metadata.Api.MessageSenders;

/// <summary>
/// Class for sending messages related to master tag categories
/// </summary>
public class MasterTagCategoriesMessageSender : BaseMetadataMessageSender, IMasterTagCategoriesMessageSender
{
    /// <summary>
    /// Constructor for MasterTagCategoriesMessageSender
    /// </summary>
    /// <param name="sender">The message sender used to send messages to the pub/sub system</param>
    /// <param name="logger">The logger used to log information</param>
    /// <param name="mediator">The mediator used to send queries and commands</param>
    /// <param name="mapper">The mapper used to map objects</param>
    /// <returns></returns>
    public MasterTagCategoriesMessageSender(IMessageSender sender, ILogger<MasterTagCategoriesMessageSender> logger, IMediator mediator, IMapper mapper) : base(sender, logger, mediator, mapper)
    {
    }
    
    /// <summary>
    /// Send a message to create a master tag category
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTagCategory">The master tag category to create</param>
    /// <returns></returns>
    public async Task SendCreateMasterTagCategoryMessageAsync(ClaimsPrincipal user,
        MasterTagCategoryDto masterTagCategory)
        => await SendMessage(user, masterTagCategory, TopicNames.MasterTagCategoryCreate);
    
    /// <summary>
    /// Send a message to update a master tag category
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTagCategory">The master tag category to update</param>
    /// <returns></returns>
    public async Task SendUpdateMasterTagCategoryMessageAsync(ClaimsPrincipal user,
        MasterTagCategoryDto masterTagCategory)
        => await SendMessage(user, masterTagCategory, TopicNames.MasterTagCategoryUpdate);
    
    /// <summary>
    /// Send a message to delete a master tag category
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="masterTagCategory">The master tag category to delete</param>
    /// <returns></returns>
    public async Task SendDeleteMasterTagCategoryMessageAsync(ClaimsPrincipal user,
        MasterTagCategoryDto masterTagCategory)
        => await SendMessage(user, masterTagCategory, TopicNames.MasterTagCategoryDelete);
    

    private async Task SendMessage(ClaimsPrincipal user, MasterTagCategoryDto masterTagCategory, string eventType)
    {
        var domains = await Mediator.Send(new ListDomainsQuery(user, Logger));

        foreach (var dto in domains.Select(domain => new MasterTagCategoryEventDto
                 {
                     Domain = domain.Name, MasterTagCategory = Mapper.Map<MasterTagCategoryResponse>(masterTagCategory)
                 }))
        {
            await MessageSender.SendEventAsync(eventType, user.GetUserId(), dto);
        }
    }

    
}