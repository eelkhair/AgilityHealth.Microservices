namespace AH.Metadata.Domain.Entities;

public class Industry : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public bool IsDefault { get; set; }
}