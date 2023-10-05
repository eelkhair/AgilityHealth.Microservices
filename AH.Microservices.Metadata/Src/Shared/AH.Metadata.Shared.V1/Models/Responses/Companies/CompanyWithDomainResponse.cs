using AH.Metadata.Shared.V1.Models.Responses.Domains;

namespace AH.Metadata.Shared.V1.Models.Responses.Companies;

public class CompanyWithDomainResponse : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public DomainResponse Domain { get; set; } = null!;
}