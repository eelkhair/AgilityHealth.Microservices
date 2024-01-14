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
}