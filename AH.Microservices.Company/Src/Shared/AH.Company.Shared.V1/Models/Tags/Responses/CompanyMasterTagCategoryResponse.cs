using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyMasterTagCategoryResponse: BaseResponse
{
    public string Name { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<CompanyMasterTagResponse> MasterTags { get; set; } = new();

}