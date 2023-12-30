namespace AH.Metadata.Shared.V1.Models.Responses.MasterTags;

/// <summary>
/// Represents an MasterTagResponse.
/// </summary>
public class MasterTagWithCategoryAndParentTagResponse : MasterTagResponse
{
    /// <summary>
    /// MasterTagCategoryUId
    /// </summary>
    public Guid MasterTagCategoryUId { get; set; }
    /// <summary>
    /// MasterTagCategoryName
    /// </summary>
    public string MasterTagCategoryName { get; set; } = string.Empty;
    
    /// <summary>
    /// ParentMasterTagUId  
    /// </summary>
    public Guid? ParentMasterTagUId { get; set; }
    
    /// <summary>
    /// ParentMasterTagName
    /// </summary>
    public string? ParentMasterTagName { get; set; }
    
    /// <summary>
    /// ParentMasterTagCategoryUId
    /// </summary>
    public Guid? ParentMasterTagCategoryUId { get; set; }
    
    /// <summary>
    /// ParentMasterTagCategoryName
    /// </summary>
    public string? ParentMasterTagCategoryName { get; set; }


}