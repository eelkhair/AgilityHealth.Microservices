using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class GrowthPlanStatusDto   : BaseDto
{
    public required string Status { get; set; }
}