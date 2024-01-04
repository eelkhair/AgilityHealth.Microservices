namespace AH.Company.Domain.Entities;

public partial class CompanyTeamMemberCategory : BaseAuditableEntity
{
    public CompanyTeamMemberCategory()
    {
        CompanyTeamMemberTags = new List<CompanyTeamMemberTag>();
    }
    public int CompanyId { get; set; }
    public int? MasterTagCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public ICollection<CompanyTeamMemberTag> CompanyTeamMemberTags { get; set; }
    public Company Company { get; set; }
    public MasterTagCategory MasterTagCategory { get; set; }
}
