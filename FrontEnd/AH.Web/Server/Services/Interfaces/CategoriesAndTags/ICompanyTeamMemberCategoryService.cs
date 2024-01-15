using AH.Company.Shared.V1.Models.Tags.Responses;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface ICompanyTeamMemberCategoryService
{
    Task<List<CompanyCategoryResponse>> GetCompanyTeamMemberCategories(Guid companyUId);
    Task<CompanyCategoryResponse> CreateCompanyTeamMemberCategory(CompanyCategoryResponse category);
    Task<CompanyCategoryResponse> UpdateCompanyTeamMemberCategory(CompanyCategoryResponse category);
    Task DeleteCompanyTeamMemberCategory(Guid uid);
}