using AH.Metadata.Shared.V1.Models.Responses.Domains;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class DomainService : IDomainService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DomainService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<List<DomainWithCompaniesResponse>> GetDomains() => await _httpClient.Get<DomainWithCompaniesResponse>("v1/domains", _httpContextAccessor);

    public async Task<DomainWithCompaniesResponse> UpdateDomain(DomainWithCompaniesResponse domain)
        => await _httpClient.Upsert<DomainWithCompaniesResponse>($"v1/domains/{domain.UId}", domain, true, _httpContextAccessor);

    public async Task<DomainWithCompaniesResponse> CreateDomain(DomainWithCompaniesResponse domain) =>
         await _httpClient.Upsert<DomainWithCompaniesResponse>($"v1/domains", domain, false, _httpContextAccessor);

    public async Task DeleteDomain(Guid uid) => await _httpClient.Delete($"v1/domains/{uid}", _httpContextAccessor);
    
}