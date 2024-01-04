namespace AH.Company.Domain.Entities;

public partial class CompanyTeamMemberTag : BaseAuditableEntity
{
    public int? CompanyTeamTagId { get; set; }
    public int CompanyTeamMemberCategoryId { get; set; }
    public int? MasterTagId { get; set; }
    public string Name { get; set; }
    public virtual MasterTag? MasterTag { get; set; }
    public virtual CompanyTeamMemberCategory CompanyTeamMemberCategory { get; set; }
    public virtual CompanyTeamTag? CompanyTeamTag { get; set; }
}
