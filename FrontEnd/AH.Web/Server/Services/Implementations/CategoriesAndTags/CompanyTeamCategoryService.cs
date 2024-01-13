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
  
}