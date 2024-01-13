using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanySkillTagResponse : BaseResponse
{
    public string Name { get; set; } = null!;
    public CompanyCategoryResponse? CompanySkillCategory { get; set; }
    public CompanyMasterTagResponse? MasterTag { get; set; }
}