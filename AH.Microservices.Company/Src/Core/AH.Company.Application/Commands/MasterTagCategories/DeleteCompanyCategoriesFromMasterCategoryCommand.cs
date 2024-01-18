using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class DeleteCompanyCategoriesFromMasterCategoryCommand(ClaimsPrincipal user, ILogger logger, MasterTagCategoryDto category,  string domain) : BaseCommand<Unit>(user, logger)
{
    public MasterTagCategoryDto Category { get; } = category;
    public string Domain { get; } = domain;
}

public class DeleteCompanyCategoriesFromMasterCategoryCommandHandler(
    ICompanyMicroServiceDbContext context,
    IMapper mapper,
    ActivitySource activitySource) : BaseCommandHandler(context, mapper),
    IRequestHandler<DeleteCompanyCategoriesFromMasterCategoryCommand, Unit>
{
    private ActivitySource ActivitySource { get; } = activitySource;

    public async Task<Unit> Handle(DeleteCompanyCategoriesFromMasterCategoryCommand request,
        CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        request.Logger.LogInformation(
            "Deleting company categories from master category with name {Name} for domain {Domain}",
            request.Category.Name, request.Domain);
        var activity = ActivitySource.StartActivity("DeleteCompanyCategoriesFromMasterCategoryCommandHandler",
            ActivityKind.Producer);
        activity?.SetTag("Domain", request.Domain);
        activity?.SetTag("Category", request.Category);
        activity?.SetTag("User", request.User.Identity?.Name);

        switch (request.Category.ClassName)
        {
            case "MasterTeamCategory":
                await DeleteCompanyTeamCategory(request.Category,  cancellationToken);
                break;
            case "MasterStakeholderCategory":
                await DeleteCompanyStakeholderCategory(request.Category,  cancellationToken);
                break;
            case "MasterSkillsCategory":
                await DeleteCompanySkillCategory(request.Category, cancellationToken);
                break;
            case "MasterTeamMemberCategory":
                await DeleteCompanyTeamMemberCategory(request.Category, cancellationToken);
                break;
        }
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        activity?.Stop();
        return Unit.Value;
    }

    private async Task DeleteCompanyTeamCategory(MasterTagCategoryDto category,  CancellationToken cancellationToken)
    {
        var companyTeamCategories = await Context.CompanyTeamCategories.Where(x => x.MasterTagCategoryId == category.Id && x.Name == category.Name && x.Type == category.Type).ToListAsync(cancellationToken);
        Context.CompanyTeamCategories.RemoveRange(companyTeamCategories);
    }
    
    private async Task DeleteCompanyStakeholderCategory(MasterTagCategoryDto category,CancellationToken cancellationToken)
    {
        var companyStakeholderCategories = await Context.CompanyStakeholderCategories.Where(x => x.MasterTagCategoryId == category.Id && x.Name == category.Name && x.Type == category.Type).ToListAsync(cancellationToken);
        Context.CompanyStakeholderCategories.RemoveRange(companyStakeholderCategories);
    }
    
    private async Task DeleteCompanySkillCategory(MasterTagCategoryDto category, CancellationToken cancellationToken)
    {
        var companySkillCategories = await Context.CompanySkillCategories.Where(x => x.MasterTagCategoryId == category.Id && x.Name == category.Name && x.Type == category.Type).ToListAsync(cancellationToken);
        Context.CompanySkillCategories.RemoveRange(companySkillCategories);
    }
    
    private async Task DeleteCompanyTeamMemberCategory(MasterTagCategoryDto category, CancellationToken cancellationToken)
    {
        var companyTeamMemberCategories = await Context.CompanyTeamMemberCategories.Where(x => x.MasterTagCategoryId == category.Id && x.Name == category.Name && x.Type == category.Type).ToListAsync(cancellationToken);
        Context.CompanyTeamMemberCategories.RemoveRange(companyTeamMemberCategories);
    }
}