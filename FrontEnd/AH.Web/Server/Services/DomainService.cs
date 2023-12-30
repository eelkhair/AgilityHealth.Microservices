using System.Net.Http.Headers;
using AH.Metadata.Shared.V1.Models.Responses.Domains;
using AH.Web.Server.Services.Interfaces;

namespace AH.Web.Server.Services;

public class DomainService : IDomainService
{
    private readonly HttpClient _httpClient;
    public DomainService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        var token = httpContextAccessor?.HttpContext?.Request.Headers["Authorization"].ToString() ?? string.Empty;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", string.Empty));
    }

    public async Task<List<DomainResponse>> GetDomains()
    {
        return await _httpClient.Get<DomainResponse>("v1/domains");
    }

    public async Task<DomainResponse> UpdateDomain(DomainResponse domain)
    {
        return await _httpClient.Upsert<DomainResponse>($"v1/domains/{domain.UId}", domain, true);
    }

    public async Task<DomainResponse> CreateDomain(DomainResponse domain)
    {
        return await _httpClient.Upsert<DomainResponse>($"v1/domains/{domain.UId}", domain, false);
    }

    public async Task DeleteDomain(Guid uid)
    {
        await _httpClient.Delete($"v1/domains/{uid}");
    }
}