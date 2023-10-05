using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class CompanyDto : BaseDto
{
    public required string Name { get; set; }
    public DomainDto Domain { get; set; } = null!;
}