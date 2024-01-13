using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyTeamTagResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
    public CompanyCategoryResponse? CompanyTeamTagCategory { get; set; }
    public CompanyMasterTagResponse? MasterTag { get; set; }
}