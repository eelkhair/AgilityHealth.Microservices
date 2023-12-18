namespace AH.Metadata.Domain.Entities;
public class MasterTag : BaseAuditableEntity
{
    public int MasterTagCategoryId { get; set; }
    public int? ParentMasterTagId { get; set; }
    public string Name { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public MasterTagCategory MasterTagCategory { get; set; } = null!;

}