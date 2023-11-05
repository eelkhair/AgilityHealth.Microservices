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
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MasterTagClassName ClassName { get; set; } 
    
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

/// <summary>
/// Enum for MasterTagCategory ClassNames
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum MasterTagClassName
{
    /// <summary>
    ///  Team
    /// </summary>
    MasterTeamTag,
    /// <summary>
    /// Team Member
    /// </summary>
    MasterTeamMemberTag,
    /// <summary>
    /// Stakeholders
    /// </summary>
    MasterStakeholderTag,
    /// <summary>
    /// Skills
    /// </summary>
    MasterSkillsTag
}