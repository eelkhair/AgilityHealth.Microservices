using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class CountryDto : BaseDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
}