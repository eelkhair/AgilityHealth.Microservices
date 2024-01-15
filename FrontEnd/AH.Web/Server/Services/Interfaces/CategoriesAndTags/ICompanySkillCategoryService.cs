using AH.Company.Shared.V1.Models.Tags.Responses;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface ICompanySkillCategoryService
{
    Task<List<CompanyCategoryResponse>> GetCompanySkillCategories(Guid companyUId);
    Task<CompanyCategoryResponse> CreateCompanySkillCategory(CompanyCategoryResponse category);
    Task<CompanyCategoryResponse> UpdateCompanySkillCategory(CompanyCategoryResponse category);
    Task DeleteCompanySkillCategory(Guid categoryUId);
}