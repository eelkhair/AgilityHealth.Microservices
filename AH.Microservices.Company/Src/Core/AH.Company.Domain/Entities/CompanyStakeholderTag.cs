using AH.Shared.Domain.Entities;

namespace AH.Company.Domain.Entities;

public class CompanyStakeholderTag : BaseAuditableEntity
{
    public int CompanyStakeholderCategoryId { get; set; }
    public int? MasterTagId { get; set; }
    public string Name { get; set; } = null!;
    public CompanyStakeholderCategory? CompanyStakeholderCategory { get; set; }
    public MasterTag? MasterTag { get; set; }
    
}
