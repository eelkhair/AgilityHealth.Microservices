using System.ComponentModel.DataAnnotations;

namespace AH.Metadata.Api.Models.Domain;

/// <summary>
/// Create Domain View Model
/// </summary>
public class CreateDomainViewModel
{
    /// <summary>
    /// Name of the domain
    /// </summary>
    [Required]
    public required string Name { get; set; }
}