namespace AH.Metadata.Application.Dtos;

public class MasterTagDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public MasterTagCategoryDto MasterTagCategory { get; set; } = new();
    public MasterTagDto? ParentMasterTag { get; set; }
    public List<MasterTagDto> ChildrenMasterTags { get; set; } = new();
}