using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class CreateCompanyCategoriesFromMasterCategoryCommand(ClaimsPrincipal user, ILogger logger, MasterTagCategoryDto category, string domain) : BaseCommand<Unit>(user, logger)
{
    public MasterTagCategoryDto Category { get; } = category;
    public string Domain { get; } = domain;
}

public class CreateCompanyCategoriesFromMasterCategoryCommandHandler(
    ICompanyMicroServiceDbContext context,
    IMapper mapper, ActivitySource activitySource) : BaseCommandHandler(context, mapper),
    IRequestHandler<CreateCompanyCategoriesFromMasterCategoryCommand, Unit>
{
    private ActivitySource ActivitySource { get; } = activitySource;

    public async Task<Unit> Handle(CreateCompanyCategoriesFromMasterCategoryCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        request.Logger.LogInformation("Creating company categories from master category with name {Name} for domain {Domain}", request.Category.Name, request.Domain);
        
        var activity = ActivitySource.StartActivity("CreateCompanyCategoriesFromMasterCategoryCommandHandler", ActivityKind.Producer);
        activity?.SetTag("Domain", request.Domain);
        activity?.SetTag("Category", request.Category);
        activity?.SetTag("User", request.User.Identity?.Name);
        
        var companies = await Context.Companies.ToListAsync(cancellationToken);
        
        companies.ForEach(company =>
        {
            switch (request.Category.ClassName)
            {
                case "MasterTeamCategory":
                    CreateCompanyTeamCategory(request.Category, company);
                    break;
                case "MasterStakeholderCategory":
                    CreateCompanyStakeholderCategory(request.Category, company);
                    break;
                case "MasterSkillsCategory":
                    CreateCompanySkillCategory(request.Category, company);
                    break;
                case "MasterTeamMemberCategory":
                    CreateCompanyTeamMemberCategory(request.Category, company);
                    break;
            }
        });
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        activity?.Stop();
        return Unit.Value;
    }

    private void CreateCompanyTeamMemberCategory(MasterTagCategoryDto masterTagCategory, Domain.Entities.Company company)
    {
        var companyTeamMemberCategory = new CompanyTeamMemberCategory
        {
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
            MasterTagCategoryId = masterTagCategory.Id,
            CompanyId = company.Id
        };
        
        Context.CompanyTeamMemberCategories.Add(companyTeamMemberCategory);
    }

    private void CreateCompanySkillCategory(MasterTagCategoryDto masterTagCategory, Domain.Entities.Company company)
    {
        var companySkillCategory = new CompanySkillCategory
        {
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
            MasterTagCategoryId = masterTagCategory.Id,
            CompanyId = company.Id
        };
        
        Context.CompanySkillCategories.Add(companySkillCategory);
    }

    private void CreateCompanyStakeholderCategory(MasterTagCategoryDto masterTagCategory, Domain.Entities.Company company)
    {
        var companyStakeholderCategory = new CompanyStakeholderCategory
        {
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
            MasterTagCategoryId = masterTagCategory.Id,
            CompanyId = company.Id
        };
        
        Context.CompanyStakeholderCategories.Add(companyStakeholderCategory);
    }

    private void CreateCompanyTeamCategory(MasterTagCategoryDto masterTagCategory, Domain.Entities.Company company)
    {
        var companyTeamCategory = new CompanyTeamCategory
        {
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
            MasterTagCategoryId = masterTagCategory.Id,
            CompanyId = company.Id
        };
        
        Context.CompanyTeamCategories.Add(companyTeamCategory);
    }
}