using AH.Company.Shared.V1.Models.Tags.Responses;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface ICompanyStakeholderCategoryService
{
    Task<List<CompanyCategoryResponse>> GetCompanyStakeholderCategories(Guid companyUId);
    Task<CompanyCategoryResponse> CreateCompanyStakeholderCategory(CompanyCategoryResponse category);
    Task<CompanyCategoryResponse> UpdateCompanyStakeholderCategory(CompanyCategoryResponse category);
    Task DeleteCompanyStakeholderCategory(Guid uid);
}