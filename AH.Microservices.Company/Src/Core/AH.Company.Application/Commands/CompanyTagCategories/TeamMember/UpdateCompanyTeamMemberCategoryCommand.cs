using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.TeamMember;

public class UpdateCompanyTeamMemberCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanyTeamMemberCategoryDto category) : BaseCommand<CompanyTeamMemberCategoryDto>(user, logger)
{
    public CompanyTeamMemberCategoryDto Category { get; } = category;
}

public class UpdateCompanyTeamMemberCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<UpdateCompanyTeamMemberCategoryCommand, CompanyTeamMemberCategoryDto>
{
    public async Task<CompanyTeamMemberCategoryDto> Handle(UpdateCompanyTeamMemberCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company team member category");
        
        var companyTeamMemberCategory = await Context.CompanyTeamMemberCategories.Include(x=>x.Company).FirstAsync(x => x.UId == request.Category.UId, cancellationToken);
      
        if (request.Category.MasterTagCategory != null)
        {
            var masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
            companyTeamMemberCategory.MasterTagCategory = masterTagCategory;
        }

        companyTeamMemberCategory.Name = request.Category.Name;
        companyTeamMemberCategory.Type = request.Category.Type;
        
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        return Mapper.Map<CompanyTeamMemberCategoryDto>(companyTeamMemberCategory);
    }
}