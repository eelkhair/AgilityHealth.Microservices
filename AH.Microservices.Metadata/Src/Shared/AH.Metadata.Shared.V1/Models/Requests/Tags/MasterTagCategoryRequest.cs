using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace AH.Metadata.Shared.V1.Models.Requests.Tags;

/// <summary>
/// Represents an MasterTagCategoryRequest.
/// </summary>

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class MasterTagCategoryRequest
{
    /// <summary>
    /// MasterTagCategory Name 
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// MasterTagCategory ClassName
    /// </summary>
    [Required]
    public string ClassName { get; set; } = null!;

    /// <summary>
    /// MasterTagCategory Type
    /// </summary>
    [Required]
    public string Type { get; set; } = null!;

}