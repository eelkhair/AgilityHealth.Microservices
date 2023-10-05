using System.ComponentModel.DataAnnotations;

namespace AH.Metadata.Shared.V1.Models.Requests.Domains;

/// <summary>
/// Create Domain Request
/// </summary>
public class DomainRequest
{
    /// <summary>
    /// Name of the domain
    /// </summary>
    [Required]
    public required string Name { get; set; }
}