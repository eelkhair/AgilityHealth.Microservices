using System.Diagnostics;
using System.Text.Json;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.User.Application.Commands.Auth;
using AH.User.Application.Dtos;
using AH.User.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.User.Api.MessageListeners;

/// <summary>
/// Message listeners for company
/// </summary>
public class CompanyListeners : BaseMessageListener
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <param name="activitySource"></param>
    public CompanyListeners(IMapper mapper, ILogger<CompanyListeners> logger, IMediator mediator, ActivitySource activitySource) : base(mapper, logger, mediator)
    {
        _activitySource = activitySource ?? throw new ArgumentNullException(nameof(activitySource));
    }
    
    private readonly ActivitySource _activitySource;

    /// <summary>
    /// Listener for CompanyCreate event
    /// </summary>
    /// <param name="message"></param>
    [Topic(PubSubNames.RabbitMq, TopicNames.CompanyCreate)]
    [HttpPost("CreateCompany")]
    public async Task CreateCompanyListener(EventDto<CompanyWithDomainResponse?> message)
    {
        var company = (message.Data);

        if (company is null)
        {
            Logger.LogError("Received message is null");
            return;
        }

        var dto = Mapper.Map<CompanyDto>(company);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }

        Logger.LogInformation("Received message: {@Model}", message);
        
        using var activity = _activitySource.StartActivity("Saving company to Auth0");
        activity?.SetTag("Company", JsonSerializer.Serialize(dto));
        
        var command = new CreateAuthCompanyCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(command);
    }
    
    /// <summary>
    /// Listener for CompanyUpdate event
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [Topic(PubSubNames.RabbitMq, TopicNames.CompanyUpdate)]
    [HttpPost("UpdateCompany")]
    public async Task UpdateCompanyListener(EventDto<CompanyWithDomainResponse?> message)
    {
        var company = message.Data;
        
        if (company is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
        var dto = Mapper.Map<CompanyDto>(company);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", message);
        
        using var activity = _activitySource.StartActivity("Updating company in Auth0");
        activity?.SetTag("Company", JsonSerializer.Serialize(dto));
        
        var command = new UpdateAuthCompanyCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(command);
    }
    
    /// <summary>
    /// Listener for CompanyDelete event
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [Topic(PubSubNames.RabbitMq, TopicNames.CompanyDelete)]
    [HttpPost("DeleteCompany")]
    public async Task DeleteCompanyListener(EventDto<CompanyWithDomainResponse?> message)
    {
        var company = message.Data;
        
        if (company is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
        var dto = Mapper.Map<CompanyDto>(company);
        if (dto is null)
        {
            Logger.LogError("Received message is null");
            return;
        }
            
        Logger.LogInformation("Received message: {@Model}", message);
        
        using var activity = _activitySource.StartActivity("Deleting company in Auth0");
        activity?.SetTag("Company", JsonSerializer.Serialize(dto));
        
        var command = new DeleteAuthCompanyCommand(CreateUser(message.UserId), Logger, dto);
        await Mediator.Send(command);
    }
}