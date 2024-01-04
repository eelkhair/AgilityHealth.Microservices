namespace AH.Company.Application.Dtos;

public class MasterTagCategoryDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<MasterTagDto>? MasterTags { get; set; } = new();
}