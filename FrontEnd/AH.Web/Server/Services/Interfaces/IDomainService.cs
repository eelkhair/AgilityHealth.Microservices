using AH.Metadata.Shared.V1.Models.Responses.Domains;

namespace AH.Web.Server.Services.Interfaces;

public interface IDomainService
{
    Task<List<DomainWithCompaniesResponse>> GetDomains();
    Task<DomainWithCompaniesResponse> UpdateDomain(DomainWithCompaniesResponse domain);
    Task<DomainWithCompaniesResponse> CreateDomain(DomainWithCompaniesResponse domain);
    Task DeleteDomain(Guid uid);
}