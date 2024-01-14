using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanySkillTagService : ICompanySkillTagService
{
    private readonly HttpClient _httpClient;
    
    public CompanySkillTagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyTagResponse>> GetCompanySkillTags(Guid companySkillCategoryUId) => await _httpClient.GetList<CompanyTagResponse>($"/api/companyskilltags/{companySkillCategoryUId}");
  
}