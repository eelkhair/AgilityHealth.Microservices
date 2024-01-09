namespace AH.Company.Application.Dtos;

public class CompanyStakeholderTagDto : BaseDto
{
 
    public string Name { get; set; } = null!;
    public CompanyStakeholderCategoryDto? CompanyStakeholderCategory { get; set; }
    public MasterTagDto? MasterTag { get; set; }
    
}
