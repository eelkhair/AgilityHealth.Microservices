namespace AH.Company.Domain.Entities;

public class CompanySkillCategory : BaseAuditableEntity
{    
    public int CompanyId { get; set; }
    public int? MasterTagCategoryId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public ICollection<CompanySkillTag> CompanySkillTags { get; set; } = new List<CompanySkillTag>();
    public Company Company { get; set; }
    public MasterTagCategory? MasterTagCategory { get; set; }
}
