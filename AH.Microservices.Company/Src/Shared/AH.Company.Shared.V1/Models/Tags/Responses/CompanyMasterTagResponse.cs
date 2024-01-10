using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyMasterTagResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public CompanyMasterTagCategoryResponse? MasterTagCategory { get; set; }
}