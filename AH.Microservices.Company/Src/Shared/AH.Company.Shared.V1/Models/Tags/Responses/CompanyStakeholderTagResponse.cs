using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyStakeholderTagResponse : BaseResponse
{
    public string Name { get; set; } = null!;
    public CompanyCategoryResponse? CompanyStakeholderCategory { get; set; }
    public CompanyMasterTagResponse? MasterTag { get; set; }
}