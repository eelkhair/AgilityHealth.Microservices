namespace AH.Company.Application.Dtos;

public partial class CompanyTeamMemberCategoryDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public List<CompanyTeamMemberTagDto> CompanyTeamMemberTags { get; set; } = new();
    public CompanyDto? Company { get; set; }
    public MasterTagCategoryDto? MasterTagCategory { get; set; }
}
