using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class IndustryDto : BaseDto
{
    public required string Name { get; set; }
    public bool IsDefault { get; set; }
}