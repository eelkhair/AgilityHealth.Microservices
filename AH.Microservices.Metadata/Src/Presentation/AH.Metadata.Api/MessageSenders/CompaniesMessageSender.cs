using System.Security.Claims;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application.Extensions;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AutoMapper;
using MediatR;

namespace AH.Metadata.Api.MessageSenders;

/// <summary>
/// class for sending messages related to companies
/// </summary>
public class CompaniesMessageSender : BaseMetadataMessageSender, ICompaniesMessageSender
{
    /// <summary>
    /// Constructor for CompaniesMessageSender
    /// </summary>
    /// <param name="sender">The message sender used to send messages to the pub/sub system</param>
    /// <param name="logger">The logger used to log information</param>
    /// <param name="mediator">The mediator used to send queries and commands</param>
    /// <param name="mapper">The mapper used to map objects</param>
    /// <returns></returns>
    
    public CompaniesMessageSender(IMessageSender sender, ILogger<CompaniesMessageSender> logger, IMediator mediator, IMapper mapper) : base(sender, logger, mediator, mapper)
    {
    }

    /// <summary>
    /// Send a message to create a company
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="company">The company to create</param>
    /// <returns></returns>
    public async Task SendCreateCompanyMessageAsync(ClaimsPrincipal user, CompanyWithDomainResponse company)
    {
        await MessageSender.SendEventAsync("CompanyCreate", user.GetUserId(), company);
    }
    
    /// <summary>
    /// Send a message to update a company
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="company">The company to update</param>
    /// <returns></returns>
    public async Task SendUpdateCompanyMessageAsync(ClaimsPrincipal user, CompanyWithDomainResponse company)
    {
        await MessageSender.SendEventAsync("CompanyUpdate", user.GetUserId(), company);
    }
    
    /// <summary>
    /// Send a message to delete a company
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="company">The company to delete</param>
    /// <returns></returns>
    public async Task SendDeleteCompanyMessageAsync(ClaimsPrincipal user, CompanyWithDomainResponse company)
    {
        await MessageSender.SendEventAsync("CompanyDelete", user.GetUserId(), company);
    }
}