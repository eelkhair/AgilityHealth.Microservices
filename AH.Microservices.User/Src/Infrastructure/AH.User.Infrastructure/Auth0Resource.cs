using AH.Integration.Auth0.ServiceAgent;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;

namespace AH.User.Infrastructure;

public class Auth0Resource(IAuth0Resource auth0Resource) : IAuthResource
{
    public Task<string> GetTokenAsync() => auth0Resource.GetTokenAsync();

    public async Task<CompanyDto> CreateAuthCompanyAsync(CompanyDto company, CancellationToken cancellationToken)
    {
        var org = await auth0Resource.CreateOrganizationAsync(company.Name, company.UId, company.DomainUId, cancellationToken);
        
        return new CompanyDto(new Guid(org.Dto.Name), org.Dto.DisplayName, org.Dto.Metadata["domainUId"].ToString());
    }
    
    public async Task<CompanyDto> UpdateAuthCompanyAsync(CompanyDto company, CancellationToken cancellationToken)
    {
        var org = await auth0Resource.UpdateOrganizationAsync(company.Name, company.UId,  company.DomainUId, cancellationToken);
        
        return new CompanyDto(new Guid(org.Dto.Name), org.Dto.DisplayName, org.Dto.Metadata["domainUId"].ToString());
    }

    public Task DeleteAuthCompanyAsync(CompanyDto company, CancellationToken cancellationToken)
    {
        return auth0Resource.DeleteOrganizationAsync(company.UId.ToString(), cancellationToken);
    }
}