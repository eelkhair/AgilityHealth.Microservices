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
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MasterTagCategoryClassNames ClassName { get; set; }
    /// <summary>
    /// MasterTagCategory Type
    /// </summary>
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MasterTagCategoryTypes Type { get; set; }
    
}

/// <summary>
/// Enum for MasterTagCategory Type
///  </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum MasterTagCategoryTypes
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    All,
    Individual,
    Team, 
    MultiTeam, 
    Enterprise
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
/// Enum for MasterTagCategory ClassNames
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum MasterTagCategoryClassNames
{
    /// <summary>
    ///  Team
    /// </summary>
    MasterTeamCategory,
    /// <summary>
    /// Team Member
    /// </summary>
    MasterTeamMemberCategory,
    /// <summary>
    /// Stakeholders
    /// </summary>
    MasterStakeholderCategory,
    /// <summary>
    /// Skills
    /// </summary>
    MasterSkillsCategory
}