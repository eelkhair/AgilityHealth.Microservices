
namespace AH.Company.Domain.Entities;

public class CompanyTeamCategory : BaseAuditableEntity
{
    public CompanyTeamCategory()
    {
        CompanyTeamTags = new List<CompanyTeamTag>();       
    }
    public int CompanyId { get; set; }
    public int? MasterTagCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public ICollection<CompanyTeamTag> CompanyTeamTags { get; set; }
    public Company Company { get; set; }
    public MasterTagCategory MasterTagCategory { get; set; }
}
