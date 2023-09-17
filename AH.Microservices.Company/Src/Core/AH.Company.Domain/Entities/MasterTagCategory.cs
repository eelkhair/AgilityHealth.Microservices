using AH.Shared.Domain.Entities;

namespace AH.Company.Domain.Entities;

public class MasterTagCategory : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public string? Type { get; set; }
    public int MetadataId { get; set; }
    public ICollection<MasterTag> MasterTags { get; set; }
    public ICollection<CompanySkillCategory>? CompanySkillCategories { get; set; }
    public ICollection<CompanyStakeholderCategory> CompanyStakeholderCategories { get; set; }
    public ICollection<CompanyTeamCategory> CompanyTeamCategories { get; set; }
    public ICollection<CompanyTeamMemberCategory> CompanyTeamMemberCategories { get; set; }
}
