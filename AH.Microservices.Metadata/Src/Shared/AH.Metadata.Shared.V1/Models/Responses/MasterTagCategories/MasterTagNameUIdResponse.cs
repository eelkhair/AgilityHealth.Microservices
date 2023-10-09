using System.Diagnostics.CodeAnalysis;

namespace AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

/// <summary>
/// Represents an MasterTag.
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class MasterTagNameUIdResponse : BaseResponse
{
    /// <summary>
    /// MasterTag Name
    /// </summary>
    
    public string Name { get; set; } = null!;

}