using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Team;

public class CreateCompanyTeamCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanyTeamCategoryDto category) : BaseCommand<CompanyTeamCategoryDto>(user, logger)
{
    public CompanyTeamCategoryDto Category { get; } = category;
}

public class CreateCompanyTeamCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<CreateCompanyTeamCategoryCommand, CompanyTeamCategoryDto>
{
    public async Task<CompanyTeamCategoryDto> Handle(CreateCompanyTeamCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company team category");
        
        var company = await Context.Companies.FirstOrDefaultAsync(x => x.UId == request.Category.Company!.UId, cancellationToken);
        
        MasterTagCategory? masterTagCategory = null;

        if (request.Category.MasterTagCategory != null)
        {
            masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
        }
        var companyTeamCategory = new CompanyTeamCategory
        {
            Name = request.Category.Name,
            Type = request.Category.Type,
            Company = company!,
            MasterTagCategoryId = masterTagCategory?.Id
        };
        
        await Context.CompanyTeamCategories.AddAsync(companyTeamCategory, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Mapper.Map<CompanyTeamCategoryDto>(companyTeamCategory);
    }
}