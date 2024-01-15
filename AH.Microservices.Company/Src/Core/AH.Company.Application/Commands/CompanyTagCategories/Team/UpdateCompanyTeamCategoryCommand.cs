using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Team;

public class UpdateCompanyTeamCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanyTeamCategoryDto category) : BaseCommand<CompanyTeamCategoryDto>(user, logger)
{
    public CompanyTeamCategoryDto Category { get; } = category;
}

public class UpdateCompanyTeamCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<UpdateCompanyTeamCategoryCommand, CompanyTeamCategoryDto>
{
    public async Task<CompanyTeamCategoryDto> Handle(UpdateCompanyTeamCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company team category");
        
        var companyTeamCategory = await Context.CompanyTeamCategories.Include(x=>x.Company).FirstAsync(x => x.UId == request.Category.UId, cancellationToken);

        if (request.Category.MasterTagCategory != null)
        {
            var masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory!.UId, cancellationToken);
            companyTeamCategory.MasterTagCategory= masterTagCategory;
        }
        
        companyTeamCategory.Name = request.Category.Name;
        companyTeamCategory.Type = request.Category.Type;
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        return Mapper.Map<CompanyTeamCategoryDto>(companyTeamCategory);
    }
}