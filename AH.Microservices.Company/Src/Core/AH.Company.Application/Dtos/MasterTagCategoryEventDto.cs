namespace AH.Company.Application.Dtos;


public class MasterTagCategoryEventDto
{
    public MasterTagCategoryDto MasterTagCategory { get; set; } = new();
    public string Domain { get; set; } 
}
