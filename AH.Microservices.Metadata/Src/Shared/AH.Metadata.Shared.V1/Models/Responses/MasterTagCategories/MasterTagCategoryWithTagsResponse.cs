namespace AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

/// <summary>
/// Represents an MasterTagCategoryWithTagsResponse.
/// </summary>
public class MasterTagCategoryWithTagsResponse : MasterTagCategoryResponse
{
    /// <summary>
    /// MasterTagCategoryWithTagsResponse Tags
    /// </summary>
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<MasterTagNameUIdResponse> MasterTags { get; set; } = new();
}