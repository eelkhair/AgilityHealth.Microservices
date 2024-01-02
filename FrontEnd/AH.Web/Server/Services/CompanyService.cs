using AH.Metadata.Shared.V1.Models.Requests.Companies;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class CompanyService : ICompanyService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CompanyService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CompanyWithDomainResponse> UpdateCompany(CompanyWithDomainResponse company)
        => await _httpClient.Upsert<CompanyWithDomainResponse>($"v1/companies/{company.UId}", company, true, _httpContextAccessor);

    public async Task<CompanyWithDomainResponse> CreateCompany(CompanyWithDomainResponse company) =>
         await _httpClient.Upsert<CompanyWithDomainResponse>($"v1/companies", BuildCreateRequest(company), false, _httpContextAccessor);

    public async Task DeleteCompany(Guid uid) => await _httpClient.Delete($"v1/companies/{uid}", _httpContextAccessor);
    
    
    private static CreateCompanyRequest BuildCreateRequest(CompanyWithDomainResponse company)
    {
        return new CreateCompanyRequest
        {
            Name = company.Name,
            DomainUId = company.Domain.UId
        };
    }
}