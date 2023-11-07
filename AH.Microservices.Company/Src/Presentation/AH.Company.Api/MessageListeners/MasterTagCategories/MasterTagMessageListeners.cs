using System.Text.Json;
using AH.Company.Application.Commands.MasterTags;
using AH.Company.Application.Dtos;
using AH.Metadata.Shared.V1.Events;
using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners.MasterTagCategories;

/// <summary>
/// Listeners for MasterTag events
/// </summary>
public class MasterTagMessageListeners : BaseMessageListener
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public MasterTagMessageListeners(IMapper mapper, ILogger<MasterTagMessageListeners> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }

    /// <summary>
    /// Listener for MasterTagCreate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "MasterTagCreate")]
    [Route("CreateMasterTagListener")]
    public async Task CreateMasterTagListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<MasterTagEventDto>(message.Data);
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        var dto = Mapper.Map<MasterTagDto>(model.MasterTag);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new CreateMasterTagCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
        
    /// <summary>
    /// Listener for MasterTagUpdate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "MasterTagUpdate")]
    [Route("UpdateMasterTagListener")]
    public async Task UpdateMasterTagListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<MasterTagEventDto>(message.Data);
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        var dto = Mapper.Map<MasterTagDto>(model.MasterTag);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new UpdateMasterTagCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
        
    /// <summary>
    /// Listener for MasterTagDelete event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "MasterTagDelete")]
    [Route("DeleteMasterTagListener")]
    public async Task DeleteMasterTagListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<MasterTagEventDto>(message.Data);
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        var dto = Mapper.Map<MasterTagDto>(model.MasterTag);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new DeleteMasterTagCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
}