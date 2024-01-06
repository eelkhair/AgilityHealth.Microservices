using AH.User.Application.Dtos;

namespace AH.User.Application.Interfaces;

public interface IAuthResource
{
    Task<string> GetTokenAsync();
    Task<CompanyDto> CreateAuthCompanyAsync(CompanyDto company, CancellationToken cancellationToken);
    Task<CompanyDto> UpdateAuthCompanyAsync(CompanyDto company, CancellationToken cancellationToken);
    Task DeleteAuthCompanyAsync(CompanyDto company, CancellationToken cancellationToken);
}