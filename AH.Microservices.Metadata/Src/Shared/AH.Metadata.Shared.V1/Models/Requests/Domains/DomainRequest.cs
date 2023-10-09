using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AH.Metadata.Shared.V1.Models.Requests.Domains;

/// <summary>
/// Create Domain Request
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class DomainRequest
{
    /// <summary>
    /// Name of the domain
    /// </summary>
    [Required]
    public required string Name { get; set; }
}