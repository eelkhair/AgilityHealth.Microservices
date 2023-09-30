using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;
public class Company : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public int DomainId { get; set; }   
        
    public Domain Domain { get; set; } = null!;
}