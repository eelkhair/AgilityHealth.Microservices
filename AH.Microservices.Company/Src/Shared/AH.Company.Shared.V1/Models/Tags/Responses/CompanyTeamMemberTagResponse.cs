using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyTeamMemberTagResponse : BaseResponse
{
    public string? Name { get; set; } 
    public CompanyMasterTagResponse? MasterTag { get; set; }
    public CompanyTeamTagResponse? CompanyTeamTag { get; set; }
}