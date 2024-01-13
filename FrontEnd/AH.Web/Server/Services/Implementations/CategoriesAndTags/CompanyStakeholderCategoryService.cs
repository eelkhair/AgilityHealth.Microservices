using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanyStakeholderCategoryService : ICompanyStakeholderCategoryService
{
    private readonly HttpClient _httpClient;
    
    public CompanyStakeholderCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyCategoryResponse>> GetCompanyStakeholderCategories(Guid companyUId) => await _httpClient.GetList<CompanyCategoryResponse>($"/api/companystakeholdercategories/{companyUId}");
  
}