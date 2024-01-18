using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class UpdateCompanyCategoriesFromMasterCategoryCommand(ClaimsPrincipal user, ILogger logger, MasterTagCategoryDto category, MasterTagCategoryDto oldEntity, string domain) : BaseCommand<Unit>(user, logger)
{
    public MasterTagCategoryDto Category { get; } = category;
    public MasterTagCategoryDto OldEntity { get; } = oldEntity;
    public string Domain { get; } = domain;
}

public class UpdateCompanyCategoriesFromMasterCategoryCommandHandler(
    ICompanyMicroServiceDbContext context,
    IMapper mapper,
    ActivitySource activitySource) : BaseCommandHandler(context, mapper),
    IRequestHandler<UpdateCompanyCategoriesFromMasterCategoryCommand, Unit>
{
    private ActivitySource ActivitySource { get; } = activitySource;

    public async Task<Unit> Handle(UpdateCompanyCategoriesFromMasterCategoryCommand request,
        CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        request.Logger.LogInformation(
            "Updating company categories from master category with name {Name} for domain {Domain}",
            request.Category.Name, request.Domain);
        var activity = ActivitySource.StartActivity("UpdateCompanyCategoriesFromMasterCategoryCommandHandler", ActivityKind.Producer);
        activity?.SetTag("Domain", request.Domain);
        activity?.SetTag("Category", request.Category);
        activity?.SetTag("User", request.User.Identity?.Name);

        switch (request.Category.ClassName)
        {
            case "MasterTeamCategory":
                await UpdateCompanyTeamCategory(request.Category, request.OldEntity, cancellationToken);
                break;
            case "MasterStakeholderCategory":
                await UpdateCompanyStakeholderCategory(request.Category, request.OldEntity, cancellationToken);
                break;
            case "MasterSkillsCategory":
                await UpdateCompanySkillCategory(request.Category, request.OldEntity, cancellationToken);
                break;
            case "MasterTeamMemberCategory":
                await UpdateCompanyTeamMemberCategory(request.Category, request.OldEntity, cancellationToken);
                break;
        }
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        activity?.Stop();
        return Unit.Value;
    }

    private async Task UpdateCompanyTeamCategory(MasterTagCategoryDto category, MasterTagCategoryDto oldEntity, CancellationToken cancellationToken)
    {
        var companyTeamCategories = await Context.CompanyTeamCategories.Where(x => x.MasterTagCategoryId == oldEntity.Id && x.Name == oldEntity.Name && x.Type == oldEntity.Type).ToListAsync(cancellationToken);
        companyTeamCategories.ForEach(c =>
        {
            c.Name = category.Name;
            c.Type = category.Type;
            Context.Update(c);
        });
    }
    
    private async Task UpdateCompanyStakeholderCategory(MasterTagCategoryDto category, MasterTagCategoryDto oldEntity, CancellationToken cancellationToken)
    {
        var companyStakeholderCategories = await Context.CompanyStakeholderCategories.Where(x => x.MasterTagCategoryId == oldEntity.Id && x.Name == oldEntity.Name && x.Type == oldEntity.Type).ToListAsync(cancellationToken);
        companyStakeholderCategories.ForEach(c =>
        {
            c.Name = category.Name;
            c.Type = category.Type;
            Context.Update(c);
        });
    }
    
    private async Task UpdateCompanySkillCategory(MasterTagCategoryDto category, MasterTagCategoryDto oldEntity, CancellationToken cancellationToken)
    {
        var companySkillCategories = await Context.CompanySkillCategories.Where(x => x.MasterTagCategoryId == oldEntity.Id && x.Name == oldEntity.Name && x.Type == oldEntity.Type).ToListAsync(cancellationToken);
        companySkillCategories.ForEach(c =>
        {
            c.Name = category.Name;
            c.Type = category.Type;
            Context.Update(c);
        });
    }
    
    private async Task UpdateCompanyTeamMemberCategory(MasterTagCategoryDto category, MasterTagCategoryDto oldEntity, CancellationToken cancellationToken)
    {
        var companyTeamMemberCategories = await Context.CompanyTeamMemberCategories.Where(x => x.MasterTagCategoryId == oldEntity.Id && x.Name == oldEntity.Name && x.Type == oldEntity.Type).ToListAsync(cancellationToken);
        companyTeamMemberCategories.ForEach(c =>
        {
            c.Name = category.Name;
            c.Type = category.Type;
            Context.Update(c);
        });
    }
}