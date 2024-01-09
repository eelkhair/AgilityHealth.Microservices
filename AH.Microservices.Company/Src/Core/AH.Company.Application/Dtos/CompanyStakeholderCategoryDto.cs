namespace AH.Company.Application.Dtos;
public class CompanyStakeholderCategoryDto : BaseDto
{
    public int CompanyId { get; set; }
    public int? MasterTagCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public List<CompanyStakeholderTagDto> CompanyStakeholderTags { get; set; } = new();
    public CompanyDto? Company { get; set; }
    public MasterTagCategoryDto? MasterTagCategory { get; set; }
}
