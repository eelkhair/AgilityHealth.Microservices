using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace AH.Metadata.Shared.V1.Models.Requests.Tags;

/// <summary>
/// Master Tag Request
/// </summary>
public class MasterTagRequest
{
    /// <summary>
    /// MasterTag Name
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// MasterTagCategory ClassName
    /// </summary>
    [Required]
    public string ClassName { get; set; } = null!;
    
    /// <summary>
    /// MasterTagCategory UId
    /// </summary>
    [Required]
    public Guid MasterTagCategoryUId { get; set; }
    
    /// <summary>
    /// MasterTag ParentMasterTagUId
    /// </summary>
    public Guid? ParentMasterTagUId { get; set; }
}

