using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Skill;

public class CreateCompanySkillCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanySkillCategoryDto category) : BaseCommand<CompanySkillCategoryDto>(user, logger)
{
    public CompanySkillCategoryDto Category { get; } = category;
}

public class CreateCompanySkillCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<CreateCompanySkillCategoryCommand, CompanySkillCategoryDto>
{
    public async Task<CompanySkillCategoryDto> Handle(CreateCompanySkillCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company Skill category");
        
        var company = await Context.Companies.FirstOrDefaultAsync(x => x.UId == request.Category.Company!.UId, cancellationToken);

        MasterTagCategory? masterTagCategory = null;

        if (request.Category.MasterTagCategory != null)
        {
            masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
        }
        
        var companySkillCategory = new CompanySkillCategory
        {
            Name = request.Category.Name,
            Type = request.Category.Type,
            Company = company!,
            MasterTagCategoryId = masterTagCategory?.Id
        };
        
        await Context.CompanySkillCategories.AddAsync(companySkillCategory, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Mapper.Map<CompanySkillCategoryDto>(companySkillCategory);
    }
}