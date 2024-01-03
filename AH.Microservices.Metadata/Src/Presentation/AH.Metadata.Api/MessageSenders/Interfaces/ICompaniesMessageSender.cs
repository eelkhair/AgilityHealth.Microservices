using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Shared.V1.Models.Responses.Companies;

namespace AH.Metadata.Api.MessageSenders.Interfaces;

/// <summary>
/// Interface for sending messages related to companies
/// </summary>
public interface ICompaniesMessageSender
{ 
    /// <summary>
    /// Send a message to create a company
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="company">The company to create</param>
    /// <returns></returns>
    Task SendCreateCompanyMessageAsync(ClaimsPrincipal user, CompanyWithDomainResponse company);
}