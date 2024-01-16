using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanySkillCategoryService : ICompanySkillCategoryService
{
    private readonly HttpClient _httpClient;
    
    public CompanySkillCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyCategoryResponse>> GetCompanySkillCategories(Guid companyUId) => await _httpClient.GetList<CompanyCategoryResponse>($"/api/companyskillcategories/{companyUId}");
    public async Task<CompanyCategoryResponse> CreateCompanySkillCategory(CompanyCategoryResponse category) => await _httpClient.Upsert<CompanyCategoryResponse>("/api/companyskillcategories", category, false);
    public async Task<CompanyCategoryResponse> UpdateCompanySkillCategory(CompanyCategoryResponse category) => await _httpClient.Upsert<CompanyCategoryResponse>("/api/companyskillcategories", category, true);
    public async Task DeleteCompanySkillCategory(Guid uid) => await _httpClient.Delete($"/api/companyskillcategories/{uid}");
}