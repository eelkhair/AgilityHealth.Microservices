using AH.Metadata.Shared.V1.Models.Responses.Companies;
using CompanyResponse = AH.Company.Shared.V1.Models.Companies.Responses.CompanyResponse;

namespace AH.Web.Server.Services.Interfaces;

public interface ICompanyService
{
    Task<CompanyWithDomainResponse> UpdateCompany(CompanyWithDomainResponse domain);
    Task<CompanyWithDomainResponse> CreateCompany(CompanyWithDomainResponse domain);
    Task DeleteCompany(Guid uid);
    Task<List<CompanyResponse>> GetCompaniesForCurrentDomain();
    
    Task<List<CompanyWithDomainResponse>> GetCompaniesForAllDomains();
    Task<CompanyResponse?> GetCompany(Guid uid);
}