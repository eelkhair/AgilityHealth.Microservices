using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;
public class MasterTagCategory: BaseAuditableEntity
{
    public string Name { get; set; }
    public string ClassName { get; set; }
    public string Type { get; set; }
    public ICollection<MasterTag> MasterTags { get;set; } 
}