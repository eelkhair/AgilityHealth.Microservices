using System.Diagnostics;
using System.Text.Json;
using AH.Company.Application.Commands.Companies;
using AH.Company.Application.Dtos;
using AH.Company.Domain.Constants;
using AH.Metadata.Shared.V1.Events;
using AutoMapper;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners.Companies;

/// <summary>
/// Listeners for Company events
/// </summary>
/// <param name="mapper"></param>
/// <param name="logger"></param>
/// <param name="mediator"></param>

public class CompanyMessageListeners(IMapper mapper, ILogger logger, IMediator mediator, ActivitySource activitySource )  : BaseMessageListener(mapper, logger, mediator)
{
 
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
        var companyCreateActivity = activitySource.StartActivity("Creating Company");
        companyCreateActivity?.SetTag("Company dto", dto);
        var command = new CreateCompanyCommand(CreateUser(message.UserId), Logger, dto);
        var response = await Mediator.Send(command);
        
        companyCreateActivity?.SetTag("Company response", response);
        companyCreateActivity?.Stop();
        
        var copyTagsActivity = activitySource.StartActivity("Copying tags");
        copyTagsActivity?.SetTag("Company dto", dto);
        
        var copyTagsCommand = new CopyTagsCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(copyTagsCommand);
        copyTagsActivity?.Stop();
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