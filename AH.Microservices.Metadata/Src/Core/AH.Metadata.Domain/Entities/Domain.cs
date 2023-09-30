using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;

public class Domain : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Company> Companies { get; set; } = null!;
}