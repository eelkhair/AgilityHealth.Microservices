using AH.Company.Shared.V1.Models.Tags.Responses;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface ICompanyTeamCategoryService
{
    Task<List<CompanyCategoryResponse>> GetCompanyTeamCategories(Guid companyUId);
    Task<CompanyCategoryResponse> CreateCompanyTeamCategory(CompanyCategoryResponse category);
    Task<CompanyCategoryResponse> UpdateCompanyTeamCategory(CompanyCategoryResponse category);
    Task DeleteCompanyTeamCategory(Guid uid);
}