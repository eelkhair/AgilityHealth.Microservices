using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;
public class Country : BaseAuditableEntity
{ 
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
}