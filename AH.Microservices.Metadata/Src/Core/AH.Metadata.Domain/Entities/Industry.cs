using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;

public class Industry : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
}