using AH.Shared.Domain.Entities;

namespace AH.Company.Domain.Entities;

public class CompanySkillTag: BaseAuditableEntity
{
    public int CompanySkillCategoryId { get; set; }
    public int? MasterTagId { get; set; }
    public string Name { get; set; }
    public CompanySkillCategory CompanySkillCategory { get; set; }
    public MasterTag? MasterTag { get; set; }
}
