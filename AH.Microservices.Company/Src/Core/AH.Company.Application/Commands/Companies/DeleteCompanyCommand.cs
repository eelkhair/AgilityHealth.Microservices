using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.Companies;

public class DeleteCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto company) : BaseCommand<Unit>(user, logger)
{
    public CompanyDto Company { get; } = company;
}

public class DeleteCompanyCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<DeleteCompanyCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Company.DomainName,request.Logger);
        var entity = await Context.Companies.FirstAsync(x => x.UId == request.Company.UId, cancellationToken);
        Context.Companies.Remove(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}