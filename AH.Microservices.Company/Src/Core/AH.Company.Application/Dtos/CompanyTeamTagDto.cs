namespace AH.Company.Application.Dtos;

public class CompanyTeamTagDto : BaseDto
{
    public string Name { get; set; } = null!;
    public MasterTagDto? MasterTag { get; set; }
    public CompanyTeamCategoryDto? CompanyTeamCategory { get; set; }
    public List<CompanyTeamMemberTagDto> CompanyTeamMemberTags { get; set; }
}
