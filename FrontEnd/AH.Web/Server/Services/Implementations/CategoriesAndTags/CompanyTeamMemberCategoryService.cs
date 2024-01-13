using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanyTeamMemberCategoryService : ICompanyTeamMemberCategoryService
{
    private readonly HttpClient _httpClient;
    
    public CompanyTeamMemberCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyCategoryResponse>> GetCompanyTeamMemberCategories(Guid companyUId) => await _httpClient.GetList<CompanyCategoryResponse>($"/api/companyteammembercategories/{companyUId}");
  
}