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
    public async Task<CompanyTagResponse> CreateCompanySkillTag(CompanyTagResponse tag) => await _httpClient.Upsert<CompanyTagResponse>($"/api/companyskilltags", tag, false);
    public async Task<CompanyTagResponse> UpdateCompanySkillTag(CompanyTagResponse tag) => await _httpClient.Upsert<CompanyTagResponse>($"/api/companyskilltags", tag, true);
    public async Task DeleteCompanySkillTag(Guid uid) => await _httpClient.Delete($"/api/companyskilltags/{uid}");
}