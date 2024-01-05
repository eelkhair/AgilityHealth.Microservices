using AH.Metadata.Shared.V1.Models.Responses.Domains;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class DomainService : IDomainService
{
    private readonly HttpClient _httpClient;

    public DomainService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<DomainWithCompaniesResponse>> GetDomains() => await _httpClient.Get<DomainWithCompaniesResponse>("v1/domains");

    public async Task<DomainWithCompaniesResponse> UpdateDomain(DomainWithCompaniesResponse domain)
        => await _httpClient.Upsert<DomainWithCompaniesResponse>($"v1/domains/{domain.UId}", domain, true);

    public async Task<DomainWithCompaniesResponse> CreateDomain(DomainWithCompaniesResponse domain) =>
         await _httpClient.Upsert<DomainWithCompaniesResponse>($"v1/domains", domain, false);

    public async Task DeleteDomain(Guid uid) => await _httpClient.Delete($"v1/domains/{uid}");
    
}