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
   
}