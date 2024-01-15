using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.TeamMember;

public class CreateCompanyTeamMemberCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanyTeamMemberCategoryDto category) : BaseCommand<CompanyTeamMemberCategoryDto>(user, logger)
{
    public CompanyTeamMemberCategoryDto Category { get; } = category;
}

public class CreateCompanyTeamMemberCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<CreateCompanyTeamMemberCategoryCommand, CompanyTeamMemberCategoryDto>
{
    public async Task<CompanyTeamMemberCategoryDto> Handle(CreateCompanyTeamMemberCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company team member category");
        
        var company = await Context.Companies.FirstOrDefaultAsync(x => x.UId == request.Category.Company!.UId, cancellationToken);

        MasterTagCategory? masterTagCategory = null;

        if (request.Category.MasterTagCategory != null)
        {
            masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
        }
        
        var companyTeamMemberCategory = new CompanyTeamMemberCategory
        {
            Name = request.Category.Name,
            Type = request.Category.Type,
            Company = company!,
            MasterTagCategoryId = masterTagCategory?.Id
        };
        
        await Context.CompanyTeamMemberCategories.AddAsync(companyTeamMemberCategory, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Mapper.Map<CompanyTeamMemberCategoryDto>(companyTeamMemberCategory);
    }
}