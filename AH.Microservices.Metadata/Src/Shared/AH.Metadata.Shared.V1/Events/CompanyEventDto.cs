using AH.Metadata.Shared.V1.Models.Responses.Companies;

namespace AH.Metadata.Shared.V1.Events;

/// <summary>
/// Event DTO for Company
/// </summary>
/// <param name="Company">The company</param>
/// <param name="Domain">The domain</param>
/// <returns></returns>
public record CompanyEventDto(CompanyWithDomainResponse Company);