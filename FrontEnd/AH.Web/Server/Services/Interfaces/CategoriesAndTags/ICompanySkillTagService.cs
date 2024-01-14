using AH.Company.Shared.V1.Models.Tags.Responses;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface ICompanySkillTagService
{
    Task<List<CompanyTagResponse>> GetCompanySkillTags(Guid companyUId);
}