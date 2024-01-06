using System.Security.Claims;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Commands.Auth;

public class DeleteAuthCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto companyDto) : BaseCommand<Unit>(user, logger)
{
    public CompanyDto CompanyDto { get; } = companyDto;
}

public class DeleteAuthCompanyCommandHandler(IUsersDbContext context, IMapper mapper, IAuthFactory authFactory, IDaprUtility daprUtility)
    : BaseCommandHandler(context, mapper), IRequestHandler<DeleteAuthCompanyCommand, Unit>
{

    private readonly IAuthResource _authResource = authFactory.CreateAuthResource();
    public async Task<Unit> Handle(DeleteAuthCompanyCommand request, CancellationToken cancellationToken)
    {
        
        await _authResource.DeleteAuthCompanyAsync(request.CompanyDto, cancellationToken);
        return Unit.Value;

    }
}