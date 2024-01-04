using System.Text.Json;
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
public class MasterTagCategoryMessageListeners : BaseMessageListener
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public MasterTagCategoryMessageListeners(IMapper mapper, ILogger<MasterTagCategoryMessageListeners> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }

    /// <summary>
    /// Listener for MasterTagCategoryCreate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "MasterTagCategoryCreate")]
    [Route("CreateMasterTagCategoryListener")]
    public async Task CreateMasterTagCategoryListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        
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
        var command = new CreateMasterTagCategoryCommand(CreateUser(message.UserId), Logger, dto, model.Domain);
        await Mediator.Send(command);
    }
        
    /// <summary>
    /// Listener for MasterTagCategoryUpdate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "MasterTagCategoryUpdate")]
    [Route("UpdateMasterTagCategoryListener")]
    public async Task UpdateMasterTagCategoryListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        
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
    [Topic(PubSubNames.RabbitMq, "MasterTagCategoryDelete")]
    [Route("DeleteMasterTagCategoryListener")]
    public async Task DeleteMasterTagCategoryListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        
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