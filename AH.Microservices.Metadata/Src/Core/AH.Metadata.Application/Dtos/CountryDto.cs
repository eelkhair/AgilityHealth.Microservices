using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class CountryDto : BaseDto
{
    public string? Name { get; set; }
    public string? Code { get; set; }
}