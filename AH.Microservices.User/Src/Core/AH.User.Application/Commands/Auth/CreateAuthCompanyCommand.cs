using System.Security.Claims;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Commands.Auth;

public class CreateAuthCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto companyDto) : BaseCommand<CompanyDto>(user, logger)
{
    public CompanyDto CompanyDto { get; } = companyDto;
}

public class CreateAuthCompanyCommandHandler(IUsersDbContext context, IMapper mapper, IAuthFactory authFactory, IDaprUtility daprUtility)
    : BaseCommandHandler(context, mapper), IRequestHandler<CreateAuthCompanyCommand, CompanyDto>
{

    private readonly IAuthResource _authResource = authFactory.CreateAuthResource();
    public async Task<CompanyDto> Handle(CreateAuthCompanyCommand request, CancellationToken cancellationToken)
    {
        
        var company = await _authResource.CreateAuthCompanyAsync(request.CompanyDto, cancellationToken);

        return company;
    }
}