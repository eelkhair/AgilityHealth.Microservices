using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Constants;
using AutoMapper;
using MediatR;

using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.Companies;

public class CreateCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto dto)
    : BaseCommand<CompanyDto>(user, logger)
{
    public CompanyDto Company { get; set; } = dto;
}

public class CreateCompanyCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IStateManager stateManager, ActivitySource activitySource)
    : BaseCommandHandler(context, mapper), IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Company.DomainName, request.Logger);

        var entity = Mapper.Map<Company.Domain.Entities.Company>(request.Company);

        Context.Companies.Add(entity);

        await Context.SaveChangesAsync(request.User, cancellationToken);

        var dto = Mapper.Map<CompanyDto>(entity);
        
        var json = JsonSerializer.Serialize(dto);
        var activity = activitySource.StartActivity($"Saving company to state store '{StateStores.Redis}");
        var companies =
            await stateManager.GetStateAsync<List<CompanyDto>?>(StateStores.Redis, StateStoreNames.Companies,
                cancellationToken) ?? [];

        if (companies.Any(x => x.UId == dto.UId)) return dto;
        dto.DomainName = request.Company.DomainName;
        companies.Add(dto);
        await stateManager.SaveStateAsync(StateStores.Redis, StateStoreNames.Companies, companies,
            cancellationToken);
        
        activity?.SetTag("Company dto", json);
        activity?.Stop();
        return dto;
    }
}