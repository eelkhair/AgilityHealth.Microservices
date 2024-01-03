using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.Companies;

public class UpdateCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto company) : BaseCommand<CompanyDto>(user, logger)
{
    public CompanyDto Company { get; set; } = company;
}

public class UpdateCompanyCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<UpdateCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Company.DomainName, request.Logger);

        var entity = await Context.Companies.FirstAsync(x=>x.UId == request.Company.UId, cancellationToken);
        
        entity.Name = request.Company.Name;
        
        Context.Companies.Update(entity);
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        return Mapper.Map<CompanyDto>(entity);
    }
}