using System.Text.Json;
using AH.Company.Application.Commands.Companies;
using AH.Company.Application.Dtos;
using AH.Metadata.Shared.V1.Events;
using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners.Companies;

/// <summary>
/// Listeners for Company events
/// </summary>
public class CompanyMessageListeners : BaseMessageListener
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyMessageListeners(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Listener for CompanyCreate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, "CompanyCreate")]
    [Route("CreateCompanyListener")]
    public async Task CreateCompanyListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<CompanyEventDto>(message.Data);
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
        var dto = Mapper.Map<CompanyDto>(model.Company);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new CreateCompanyCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(command);
    }
    
    /// <summary>
    /// Listener for CompanyUpdate event
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [Topic(PubSubNames.RabbitMq, "CompanyUpdate")]
    [Route("UpdateCompanyListener")]
    public async Task UpdateCompanyListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<CompanyEventDto>(message.Data);
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
        var dto = Mapper.Map<CompanyDto>(model.Company);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new UpdateCompanyCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(command);
    }
    
    /// <summary>
    /// Listener for CompanyDelete event
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [Topic(PubSubNames.RabbitMq, "CompanyDelete")]
    [Route("DeleteCompanyListener")]
    public async Task DeleteCompanyListener(EventDto message)
    {
        var model = JsonSerializer.Deserialize<CompanyEventDto>(message.Data);
        
        if (model is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
        var dto = Mapper.Map<CompanyDto>(model.Company);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", model);
        var command = new DeleteCompanyCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(command);
    }
}