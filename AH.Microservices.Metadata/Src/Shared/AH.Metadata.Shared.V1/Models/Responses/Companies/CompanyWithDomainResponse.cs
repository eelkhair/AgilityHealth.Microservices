using AH.Metadata.Shared.V1.Models.Responses.Domains;

namespace AH.Metadata.Shared.V1.Models.Responses.Companies;

/// <summary>
/// Represents an Company.
/// </summary>
public class CompanyWithDomainResponse : BaseResponse
{
    /// <summary>
    /// Company Name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Domain
    /// </summary>
    public DomainResponse Domain { get; set; } = null!;
}