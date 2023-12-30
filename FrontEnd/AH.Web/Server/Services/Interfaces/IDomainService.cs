using AH.Metadata.Shared.V1.Models.Responses.Domains;

namespace AH.Web.Server.Services.Interfaces;

public interface IDomainService
{
    Task<List<DomainResponse>> GetDomains();
    Task<DomainResponse> UpdateDomain(DomainResponse domain);
    Task<DomainResponse> CreateDomain(DomainResponse domain);
    Task DeleteDomain(Guid uid);
}