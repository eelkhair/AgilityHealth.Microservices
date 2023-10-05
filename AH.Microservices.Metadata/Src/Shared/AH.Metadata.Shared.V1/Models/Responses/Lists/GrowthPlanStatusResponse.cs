namespace AH.Metadata.Shared.V1.Models.Responses.Lists;

/// <summary>
/// Represent a Growth Plan Status
/// </summary>
public class GrowthPlanStatusResponse : BaseModel
{
    /// <summary>
    /// The status of the growth plan item.
    /// </summary>
    public required string Status { get; set; }
}