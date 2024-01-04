namespace AH.Company.Domain.Entities;

public class MasterTag : BaseAuditableEntity
{
    public int MasterTagCategoryId { get; set; }
    public int? ParentMasterTagId { get; set; }
    public string Name { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public MasterTagCategory MasterTagCategory { get; set; } = null!;  
    public ICollection<CompanySkillTag> CompanySkillTags { get; set; }
    public ICollection<CompanyStakeholderTag> CompanyStakeholderTags { get; set; }
    public ICollection<CompanyTeamTag> CompanyTeamTags { get; set; }
    public ICollection<CompanyTeamMemberTag> CompanyTeamMemberTags { get; set; }

}
