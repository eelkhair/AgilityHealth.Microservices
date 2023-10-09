using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AH.Metadata.Shared.V1.Models.Requests.Companies;

/// <summary>
/// Update company request
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class UpdateCompanyRequest
{
    /// <summary>
    /// Name of the company
    /// </summary>
    [Required]
    public required string Name { get; set; }
}