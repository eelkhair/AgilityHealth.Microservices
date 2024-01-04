using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.Companies;

public class CreateCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto dto)
    : BaseCommand<Unit>(user, logger)
{
    public CompanyDto Company { get; set; } = dto;
}

public class CreateCompanyCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<CreateCompanyCommand, Unit>
{
    public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Company.DomainName, request.Logger);
        
        var entity = Mapper.Map<Company.Domain.Entities.Company>(request.Company);
        
        Context.Companies.Add(entity);
        try
        {
            await Context.SaveChangesAsync(request.User, cancellationToken);
        }
        catch (Exception e)
        {
            
        }
       
        
        return Unit.Value;
    }
}