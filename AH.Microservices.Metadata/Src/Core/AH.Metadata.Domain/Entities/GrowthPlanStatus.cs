using AH.Shared.Domain.Entities;

namespace AH.Metadata.Domain.Entities;

public class GrowthPlanStatus : BaseAuditableEntity
{
    public string Status { get; set; } = null!;
}