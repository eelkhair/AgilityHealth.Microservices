using AH.Metadata.Shared.V1.Models.Responses.Companies;

namespace AH.Metadata.Shared.V1.Models.Responses.Domains;

/// <summary>
/// Domain with companies response
/// </summary>
public class DomainWithCompaniesResponse : BaseResponse
{
    /// <summary>
    /// Name of the domain
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// List of companies
    /// </summary>
    // ReSharper disable once CollectionNeverUpdated.Global
    public required List<CompanyResponse> Companies { get; set; } = new();
}