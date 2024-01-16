using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanyTeamCategoryService : ICompanyTeamCategoryService
{
    private readonly HttpClient _httpClient;
    
    public CompanyTeamCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyCategoryResponse>> GetCompanyTeamCategories(Guid companyUId) => await _httpClient.GetList<CompanyCategoryResponse>($"/api/companyteamcategories/{companyUId}");
    public async Task<List<CompanyCategoryResponse>> GetCompanyTeamCategoriesWithTags(Guid companyUId) => await _httpClient.GetList<CompanyCategoryResponse>($"/api/companyteamcategories/with-tags/{companyUId}");
    public Task<CompanyCategoryResponse> CreateCompanyTeamCategory(CompanyCategoryResponse category) => _httpClient.Upsert<CompanyCategoryResponse>($"/api/companyteamcategories", category, false);
    public Task<CompanyCategoryResponse> UpdateCompanyTeamCategory(CompanyCategoryResponse category) => _httpClient.Upsert<CompanyCategoryResponse>($"/api/companyteamcategories", category, true);
    public async Task DeleteCompanyTeamCategory(Guid uid) => await _httpClient.Delete($"/api/companyteamcategories/{uid}");
}