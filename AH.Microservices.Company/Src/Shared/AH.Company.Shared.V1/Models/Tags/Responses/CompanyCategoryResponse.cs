using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyCategoryResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public CompanyResponse Company { get; set; } = null!;
    public CompanyMasterTagCategoryResponse? MasterTagCategory { get; set; }
    public List<CompanyTagResponse> Tags { get; set; } = new();
    
}