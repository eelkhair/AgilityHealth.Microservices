
namespace AH.Company.Application.Dtos;

public class CompanySkillCategoryDto : BaseDto
{    
    public string? Name { get; set; }
    public string? Type { get; set; }
    public List<CompanySkillTagDto> CompanySkillTags { get; set; } = new();
    public CompanyDto? Company { get; set; }
    public MasterTagCategoryDto? MasterTagCategory { get; set; }
}
