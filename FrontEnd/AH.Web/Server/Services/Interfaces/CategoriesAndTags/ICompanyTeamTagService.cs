using AH.Company.Shared.V1.Models.Tags.Responses;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface ICompanyTeamTagService
{
    Task<List<CompanyTagResponse>> GetCompanyTeamTags(Guid companyTeamCategoryUId);
    Task<CompanyTagResponse> CreateCompanyTeamTag(CompanyTagResponse tag);
    Task<CompanyTagResponse> UpdateCompanyTeamTag(CompanyTagResponse tag);
    Task DeleteCompanyTeamTag(Guid uid);
}