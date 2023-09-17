using AH.Shared.Domain.Entities;

namespace AH.Company.Domain.Entities;

public class CompanyTeamTag : BaseAuditableEntity
{
    public CompanyTeamTag()
    {
        this.CompanyTeamMemberTags = new List<CompanyTeamMemberTag>();
    }
    public int CompanyTeamCategoryId { get; set; }
    public int? MasterTagId { get; set; }
    public string Name { get; set; } = null!;
    public MasterTag? MasterTag { get; set; }
    public CompanyTeamCategory CompanyTeamCategory { get; set; }
    public virtual ICollection<CompanyTeamMemberTag> CompanyTeamMemberTags { get; set; }
}
