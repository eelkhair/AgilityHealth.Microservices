using AH.Metadata.Shared.V1.Models.Responses.Companies;

namespace AH.Web.Server.Services.Interfaces;

public interface ICompanyService
{
    Task<CompanyWithDomainResponse> UpdateCompany(CompanyWithDomainResponse domain);
    Task<CompanyWithDomainResponse> CreateCompany(CompanyWithDomainResponse domain);
    Task DeleteCompany(Guid uid);
}