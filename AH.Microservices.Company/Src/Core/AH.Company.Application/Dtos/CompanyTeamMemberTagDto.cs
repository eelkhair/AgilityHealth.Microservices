namespace AH.Company.Application.Dtos;

public class CompanyTeamMemberTagDto : BaseDto
{
    public string Name { get; set; }
    public virtual MasterTagDto? MasterTag { get; set; }
    public virtual CompanyTeamMemberCategoryDto CompanyTeamMemberCategory { get; set; } = null!;
    public virtual CompanyTeamTagDto? CompanyTeamTag { get; set; }
}
