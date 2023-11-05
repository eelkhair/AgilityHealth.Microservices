namespace AH.Metadata.Shared.V1.Models.Responses.MasterTags;

/// <summary>
/// Represents an MasterTagResponse.
/// </summary>
public class MasterTagResponse : BaseResponse
{
    /// <summary>
    /// MasterTag Name 
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// MasterTag ClassName
    /// </summary>
    public string ClassName { get; set; } = null!;
}