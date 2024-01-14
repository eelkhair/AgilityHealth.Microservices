using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;

namespace AH.Web.Server.Services.Implementations.CategoriesAndTags;

public class CompanyTeamMemberTagService: ICompanyTeamMemberTagService
{
    private readonly HttpClient _httpClient;

    public CompanyTeamMemberTagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CompanyTagResponse>> GetCompanyTeamMemberTags(Guid companyTeamMemberCategoryUId) => await _httpClient.GetList<CompanyTagResponse>($"/api/companyteammembertags/{companyTeamMemberCategoryUId}");
   
}