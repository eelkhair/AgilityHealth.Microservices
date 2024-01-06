using System.Security.Claims;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Commands.Auth;

public class UpdateAuthCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto companyDto) : BaseCommand<CompanyDto>(user, logger)
{
    public CompanyDto CompanyDto { get; } = companyDto;
}

public class UpdateAuthCompanyCommandHandler(IUsersDbContext context, IMapper mapper, IAuthFactory authFactory, IDaprUtility daprUtility)
    : BaseCommandHandler(context, mapper), IRequestHandler<UpdateAuthCompanyCommand, CompanyDto>
{

    private readonly IAuthResource _authResource = authFactory.CreateAuthResource();
    public async Task<CompanyDto> Handle(UpdateAuthCompanyCommand request, CancellationToken cancellationToken)
    {
        
        var company = await _authResource.UpdateAuthCompanyAsync(request.CompanyDto, cancellationToken);

        return company;
    }
}