namespace AH.Company.Domain.Entities;

public class CompanyStakeholderCategory : BaseAuditableEntity
{
    public CompanyStakeholderCategory()
    {
        CompanyStakeholderTags = new List<CompanyStakeholderTag>();
    }
    public int CompanyId { get; set; }
    public int? MasterTagCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public ICollection<CompanyStakeholderTag> CompanyStakeholderTags { get; set; }
    public Company Company { get; set; }
    public MasterTagCategory MasterTagCategory { get; set; }
}
