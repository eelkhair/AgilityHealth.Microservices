using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

namespace AH.Metadata.Shared.V1.Models.Responses.MasterTags;

/// <summary>
/// Represents an MasterTagResponse.
/// </summary>
public class MasterTagWithCategoryAndParentTagResponse : MasterTagResponse
{
    /// <summary>
    /// MasterTagCategory
    /// </summary>
    public MasterTagCategoryResponse MasterTagCategory { get; set; } = new();

    /// <summary>
    /// ParentMasterTag
    /// </summary>
    public MasterTagResponse? ParentMasterTag { get; set; }

    /// <summary>
    /// Child MasterTags
    /// </summary>
    public List<MasterTagResponse> ChildMasterTags { get; set; } = new();
}