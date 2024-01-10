namespace AH.Company.Shared.V1.Models.Tags.Responses;

public class CompanyStakeholderTagResponse
{
    public string Name { get; set; } = null!;
    public CompanyStakeholderCategoryResponse? CompanyStakeholderCategory { get; set; }
    public CompanyMasterTagResponse? MasterTag { get; set; }
}