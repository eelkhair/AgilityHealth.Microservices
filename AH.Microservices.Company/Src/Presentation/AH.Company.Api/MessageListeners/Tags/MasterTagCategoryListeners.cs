using AH.Company.Application.Commands.MasterTagCategories;
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
public class MasterTagCategoryListeners : BaseMessageListener
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public MasterTagCategoryListeners(IMapper mapper, ILogger<MasterTagCategoryListeners> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }

    /// <summary>
    /// Listener for MasterTagCategoryCreate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, TopicNames.MasterTagCategoryCreate)]
    [HttpPost("CreateMasterTagCategory")]
    public async Task CreateMasterTagCategory(EventDto<MasterTagCategoryEventDto?> message)
    {
        var model = message.Data;
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
        
        var dto = Mapper.Map<MasterTagCategoryDto>(model.MasterTagCategory);
        
        Logger.LogInformation("Received message: {@Model}", dto);
        var command = new CreateMasterTagCategoryCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
        
    /// <summary>
    /// Listener for MasterTagCategoryUpdate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, TopicNames.MasterTagCategoryUpdate)]
    [HttpPost("UpdateMasterTagCategory")]
    public async Task UpdateMasterTagCategory(EventDto<MasterTagCategoryEventDto?> message)
    {
        var model = message.Data;
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        var dto = Mapper.Map<MasterTagCategoryDto>(model.MasterTagCategory);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new UpdateMasterTagCategoryCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
        
    /// <summary>
    /// Listener for MasterTagCategoryDelete event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, TopicNames.MasterTagCategoryDelete)]
    [HttpPost("DeleteMasterTagCategory")]
    public async Task DeleteMasterTagCategory(EventDto<MasterTagCategoryEventDto?> message)
    {
        var model = message.Data;
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        var dto = Mapper.Map<MasterTagCategoryDto>(model.MasterTagCategory);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new DeleteMasterTagCategoryCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
}