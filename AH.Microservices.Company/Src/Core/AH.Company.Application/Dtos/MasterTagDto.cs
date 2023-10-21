using AH.Shared.Application.Dtos;

namespace AH.Company.Application.Dtos;

public class MasterTagDto : BaseDto
{
    public int MasterTagCategoryId { get; set; }
    public int? ParentMasterTagId { get; set; }
    public string Name { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public MasterTagCategoryDto MasterTagCategory { get; set; } = null!;
    public MasterTagDto? ParentMasterTag { get; set; }
    public List<MasterTagDto> ChildrenMasterTags { get; set; } = null!;
}