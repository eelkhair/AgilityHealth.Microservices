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
    
    /// <summary>
    /// Send a message to update a company
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="company">The company to update</param>
    /// <returns></returns>
    Task SendUpdateCompanyMessageAsync(ClaimsPrincipal user, CompanyWithDomainResponse company); 
    
    /// <summary>
    /// Send a message to delete a company
    /// </summary>
    /// <param name="user">The user sending the message</param>
    /// <param name="company">The company to delete</param>
    /// <returns></returns>
    Task SendDeleteCompanyMessageAsync(ClaimsPrincipal user, CompanyWithDomainResponse company);
}