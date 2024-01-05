using AH.Metadata.Shared.V1.Models.Requests.Companies;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.Web.Server.Services.Interfaces;
using CompanyResponse = AH.Company.Shared.V1.Models.Companies.Responses.CompanyResponse;

namespace AH.Web.Server.Services;

public class CompanyService : ICompanyService
{
    private readonly HttpClient _metadataHttpClient;
    private readonly HttpClient _companyHttpClient;

    public CompanyService(HttpClient metadataHttpClient, HttpClient companyHttpClient)
    {
        _metadataHttpClient = metadataHttpClient;
        _companyHttpClient = companyHttpClient;
    }

    public async Task<CompanyWithDomainResponse> UpdateCompany(CompanyWithDomainResponse company)
        => await _metadataHttpClient.Upsert<CompanyWithDomainResponse>($"v1/companies/{company.UId}", company, true);

    public async Task<CompanyWithDomainResponse> CreateCompany(CompanyWithDomainResponse company) =>
         await _metadataHttpClient.Upsert<CompanyWithDomainResponse>($"v1/companies", BuildCreateRequest(company), false);

    public async Task DeleteCompany(Guid uid) => await _metadataHttpClient.Delete($"v1/companies/{uid}");
    public async Task<List<CompanyResponse>> GetCompanies() => await _companyHttpClient.Get<CompanyResponse>("api/companies");
    
    private static CreateCompanyRequest BuildCreateRequest(CompanyWithDomainResponse company)
    {
        return new CreateCompanyRequest
        {
            Name = company.Name,
            DomainUId = company.Domain.UId
        };
    }
}