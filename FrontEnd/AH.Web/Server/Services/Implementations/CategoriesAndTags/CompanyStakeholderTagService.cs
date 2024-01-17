using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanyStakeholderTagService : ICompanyStakeholderTagService
{
    private readonly HttpClient _httpClient;
    
    public CompanyStakeholderTagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyTagResponse>> GetCompanyStakeholderTags(Guid companyStakeholderCategoryUId) =>
        await _httpClient.GetList<CompanyTagResponse>($"/api/companystakeholdertags/{companyStakeholderCategoryUId}");
    public async Task<CompanyTagResponse> CreateCompanyStakeholderTag(CompanyTagResponse tag) =>
        await _httpClient.Upsert<CompanyTagResponse>($"/api/companystakeholdertags", tag, false);
    public async Task<CompanyTagResponse> UpdateCompanyStakeholderTag(CompanyTagResponse tag) =>
        await _httpClient.Upsert<CompanyTagResponse>($"/api/companystakeholdertags", tag, true);
    public async Task DeleteCompanyStakeholderTag(Guid uid) => await _httpClient.Delete($"/api/companystakeholdertags/{uid}");
}