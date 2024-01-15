using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Skill;

public class UpdateCompanySkillCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanySkillCategoryDto category) : BaseCommand<CompanySkillCategoryDto>(user, logger)
{
    public CompanySkillCategoryDto Category { get; } = category;
}

public class UpdateCompanySkillCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<UpdateCompanySkillCategoryCommand, CompanySkillCategoryDto>
{
    public async Task<CompanySkillCategoryDto> Handle(UpdateCompanySkillCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company skill category");
        
        var companySkillCategory = await Context.CompanySkillCategories.Include(x=>x.Company).FirstAsync(x => x.UId == request.Category.UId, cancellationToken);
      
        if (request.Category.MasterTagCategory != null)
        {
            var masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
            companySkillCategory.MasterTagCategory = masterTagCategory;
        }

        companySkillCategory.Name = request.Category.Name;
        companySkillCategory.Type = request.Category.Type;
        
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        return Mapper.Map<CompanySkillCategoryDto>(companySkillCategory);
    }
}