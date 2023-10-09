using AH.Shared.Application.Dtos;

namespace AH.Metadata.Application.Dtos;

public class CompanyDto : BaseDto
{
    public string Name { get; set; } = null!;
    public DomainDto Domain { get; set; } = null!;
}