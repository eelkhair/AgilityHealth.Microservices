using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanyTeamTagService: ICompanyTeamTagService
{
    private readonly HttpClient _httpClient;

    public CompanyTeamTagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyTagResponse>> GetCompanyTeamTags(Guid companyTeamCategoryUId) => 
        await _httpClient.GetList<CompanyTagResponse>($"/api/companyteamtags/{companyTeamCategoryUId}");
   
    public async Task<CompanyTagResponse> CreateCompanyTeamTag(CompanyTagResponse tag) =>
        await _httpClient.Upsert<CompanyTagResponse>($"/api/companyteamtags", tag, false);
    
    public async Task<CompanyTagResponse> UpdateCompanyTeamTag(CompanyTagResponse tag) =>
        await _httpClient.Upsert<CompanyTagResponse>($"/api/companyteamtags", tag, true);
    
    public async Task DeleteCompanyTeamTag(Guid uid) =>
        await _httpClient.Delete($"/api/companyteamtags/{uid}");
}