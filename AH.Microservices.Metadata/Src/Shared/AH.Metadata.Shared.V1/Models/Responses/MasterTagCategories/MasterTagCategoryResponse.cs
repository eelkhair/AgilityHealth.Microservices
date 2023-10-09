namespace AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

/// <summary>
/// Represents an MasterTagCategory.
/// </summary>
public class MasterTagCategoryResponse : BaseResponse
{
    /// <summary>
    /// MasterTagCategory Name
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// MasterTagCategory ClassName
    /// </summary>
    public string? ClassName { get; set; }
    /// <summary>
    /// MasterTagCategory Type
    /// </summary>
    public string? Type { get; set; }
}