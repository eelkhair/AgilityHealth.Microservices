using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;
public class MasterTagCategory: BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public string Type { get; set; } = null!;
    public ICollection<MasterTag> MasterTags { get;set; } = null!;
}