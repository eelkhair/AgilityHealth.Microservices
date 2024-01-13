using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyTagResponse : BaseResponse
{
    public string? Name { get; set; } 
    public CompanyCategoryResponse? CompanyCategory { get; set; }
    public CompanyMasterTagResponse? MasterTag { get; set; }
    public CompanyTagResponse? CompanyTeamTag { get; set; }
}