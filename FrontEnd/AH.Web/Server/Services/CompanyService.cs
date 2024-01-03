using AH.Metadata.Shared.V1.Models.Requests.Companies;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.Web.Server.Services.Interfaces;
using CompanyResponse = AH.Company.Shared.V1.Models.Companies.Responses.CompanyResponse;

namespace AH.Web.Server.Services;

public class CompanyService : ICompanyService
{
    private readonly HttpClient _metadataHttpClient;
    private readonly HttpClient _companyHttpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CompanyService(HttpClient metadataHttpClient, HttpClient companyHttpClient, IHttpContextAccessor httpContextAccessor)
    {
        _metadataHttpClient = metadataHttpClient;
        _companyHttpClient = companyHttpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CompanyWithDomainResponse> UpdateCompany(CompanyWithDomainResponse company)
        => await _metadataHttpClient.Upsert<CompanyWithDomainResponse>($"v1/companies/{company.UId}", company, true, _httpContextAccessor);

    public async Task<CompanyWithDomainResponse> CreateCompany(CompanyWithDomainResponse company) =>
         await _metadataHttpClient.Upsert<CompanyWithDomainResponse>($"v1/companies", BuildCreateRequest(company), false, _httpContextAccessor);

    public async Task DeleteCompany(Guid uid) => await _metadataHttpClient.Delete($"v1/companies/{uid}", _httpContextAccessor);
    public async Task<List<CompanyResponse>> GetCompanies() => await _companyHttpClient.Get<CompanyResponse>("api/companies", _httpContextAccessor);
    
    private static CreateCompanyRequest BuildCreateRequest(CompanyWithDomainResponse company)
    {
        return new CreateCompanyRequest
        {
            Name = company.Name,
            DomainUId = company.Domain.UId
        };
    }
}