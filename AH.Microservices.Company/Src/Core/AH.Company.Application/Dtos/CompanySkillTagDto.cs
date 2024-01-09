namespace AH.Company.Application.Dtos;

public class CompanySkillTagDto: BaseDto
{
    public string Name { get; set; } = string.Empty;
    public CompanySkillCategoryDto? CompanySkillCategory { get; set; }
    public MasterTagDto? MasterTag { get; set; }
}
