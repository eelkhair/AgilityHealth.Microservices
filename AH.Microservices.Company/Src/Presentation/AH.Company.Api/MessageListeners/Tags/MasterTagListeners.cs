using AH.Company.Application.Commands.MasterTags;
using AH.Company.Application.Dtos;
using AH.Company.Domain.Constants;
using AH.Metadata.Shared.V1.Events;
using AutoMapper;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners.Tags;

/// <summary>
/// Listeners for MasterTag events
/// </summary>
public class MasterTagListeners : BaseMessageListener
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public MasterTagListeners(IMapper mapper, ILogger<MasterTagListeners> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }

    /// <summary>
    /// Listener for MasterTagCreate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "MasterTagCreate")]
    [HttpPost("CreateMasterTag")]
    public async Task CreateMasterTag(EventDto<MasterTagEventDto?> message)
    {
        var model = message.Data;
        
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
    [HttpPost("UpdateMasterTag")]
    public async Task UpdateMasterTag(EventDto<MasterTagEventDto?> message)
    {
        var model = message.Data;
        
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
    [HttpPost("DeleteMasterTag")]
    public async Task DeleteMasterTag(EventDto<MasterTagEventDto?> message)
    {
        var model = message.Data;
        
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