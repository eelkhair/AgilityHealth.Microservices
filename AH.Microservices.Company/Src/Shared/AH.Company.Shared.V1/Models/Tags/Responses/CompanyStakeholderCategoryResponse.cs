using AH.Company.Shared.V1.Models.Companies.Responses;

namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyStakeholderCategoryResponse : BaseResponse
{
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public List<CompanyStakeholderTagResponse> CompanyStakeholderTags { get; set; } = new();
    public CompanyResponse? Company { get; set; }
    public CompanyMasterTagCategoryResponse? MasterTagCategory { get; set; }
}