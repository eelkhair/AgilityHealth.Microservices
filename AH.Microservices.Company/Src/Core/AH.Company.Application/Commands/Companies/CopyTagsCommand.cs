using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Constants;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace AH.Company.Application.Commands.Companies;

public class CopyTagsCommand(ClaimsPrincipal user, ILogger logger, CompanyDto company) : BaseCommand<Unit>(user, logger)
{
    public CompanyDto Company { get; set; } = company;
}

public class CopyTagsCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper, ActivitySource activitySource, IStateManager stateManager)
    : BaseCommandHandler(context, mapper), IRequestHandler<CopyTagsCommand, Unit>
{
    public async Task<Unit> Handle(CopyTagsCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Company.DomainName, request.Logger);

        var company = await Context.Companies.FirstAsync(x => x.UId == request.Company.UId, cancellationToken);

        var allCategories = await Context.MasterTagCategories.ToListAsync(cancellationToken);
        var allTags = await Context.MasterTags.ToListAsync(cancellationToken);

        var masterTeamCategories = allCategories.Where(x => x.ClassName == "MasterTeamCategory").ToList();
        var masterTeamTags = allTags.Where(x => x.ClassName == "MasterTeamTag").ToList();
        
        var masterSkillCategories = allCategories.Where(x => x.ClassName == "MasterSkillsCategory").ToList();
        var masterSkillTags = allTags.Where(x => x.ClassName == "MasterSkillsTag").ToList();
        
        var masterTeamMemberCategories = allCategories.Where(x => x.ClassName == "MasterTeamMemberCategory").ToList();
        var masterTeamMemberTags = allTags.Where(x => x.ClassName == "MasterTeamMemberTag").ToList(); 
        
        var masterStakeholders = allCategories.Where(x => x.ClassName == "MasterStakeholderCategory").ToList();
        var masterStakeholderTags = allTags.Where(x => x.ClassName == "MasterStakeholderTag").ToList();

        masterStakeholders.ForEach(masterStakeholder =>
        {
            var teamStakeholder = masterStakeholder.CopyToCompanyStakeholderCategory();
            masterStakeholderTags.Where(x => x.MasterTagCategoryId == masterStakeholder.Id).ToList().ForEach(tag =>
            {
                var newTag = tag.CopyToCompanyStakeholderTag(teamStakeholder);
                teamStakeholder.CompanyStakeholderTags.Add(newTag);
            });

            company.CompanyStakeholderCategories.Add(teamStakeholder);
        });
        
        masterSkillCategories.ForEach(masterSkillCategory =>
        {
            var teamSkill = masterSkillCategory.CopyToCompanySkillCategory();
            masterSkillTags.Where(x => x.MasterTagCategoryId == masterSkillCategory .Id).ToList().ForEach(tag =>
            {
                var newTag = tag.CopyToCompanySkillTag(teamSkill);
                teamSkill.CompanySkillTags.Add(newTag);
            });

            company.CompanySkillCategories.Add(teamSkill);
        });

        var companyTeamTags = new List<CompanyTeamTag>();
        masterTeamCategories.ForEach(masterTeamCat =>
        {
            var teamCategory = masterTeamCat.CopyToCompanyTeamCategory();

            masterTeamTags.Where(x => x.MasterTagCategoryId == masterTeamCat.Id).ToList().ForEach(tag =>
            {
                var newTag = tag.CopyToCompanyTeamTag(teamCategory);
                teamCategory.CompanyTeamTags.Add(newTag);
                companyTeamTags.Add(newTag);
            });

            company.CompanyTeamCategories.Add(teamCategory);
        });

        var companyTeamMemberCategories = new List<CompanyTeamMemberCategory>();
        masterTeamMemberCategories.ForEach(masterTeamMemberCategory =>
        {
            var companyTeamMemberCategory = masterTeamMemberCategory.CopyToCompanyTeamMemberCategory();
            company.CompanyTeamMemberCategories.Add(companyTeamMemberCategory);
            companyTeamMemberCategories.Add(companyTeamMemberCategory);
        });

        masterTeamMemberTags.ForEach(tag =>
        {
            var companyTeamMemberCategory =
                companyTeamMemberCategories.FirstOrDefault(x => x.MasterTagCategory.Id == tag.MasterTagCategoryId);
            var companyTeamTag = companyTeamTags.FirstOrDefault(x => x.MasterTag?.Id == tag.ParentMasterTagId);
            var newTag = tag.CopyToCompanyTeamMemberTag(companyTeamMemberCategory!, companyTeamTag!);
            companyTeamMemberCategory?.CompanyTeamMemberTags.Add(newTag);
        });
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        await SaveToStateStore(request.Company.DomainName, company, cancellationToken);
        
        return Unit.Value;
    }

    private async Task SaveToStateStore(string domain, Domain.Entities.Company company, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public static class MasterTagExtensions
{
    public static CompanyTeamCategory CopyToCompanyTeamCategory(this MasterTagCategory masterTagCategory)
    {
        return new CompanyTeamCategory()
        {
            MasterTagCategory = masterTagCategory,
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
        };
    }

    public static CompanyTeamMemberCategory CopyToCompanyTeamMemberCategory(this MasterTagCategory masterTagCategory)
    {
        return new CompanyTeamMemberCategory()
        {
            MasterTagCategory = masterTagCategory,
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type
        };
    }

    public static CompanyTeamTag CopyToCompanyTeamTag(this MasterTag masterTag, CompanyTeamCategory companyTeamCategory)
    {
        return new CompanyTeamTag()
        {
            CompanyTeamCategory = companyTeamCategory,
            MasterTag = masterTag,
            Name = masterTag.Name
        };
    }

    public static CompanyTeamMemberTag CopyToCompanyTeamMemberTag(this MasterTag masterTag,
        CompanyTeamMemberCategory companyTeamMemberCategory, CompanyTeamTag companyTeamTag)
    {
        return new CompanyTeamMemberTag()
        {
            CompanyTeamMemberCategory = companyTeamMemberCategory,
            CompanyTeamTag = companyTeamTag,
            MasterTag = masterTag,
            Name = masterTag.Name,
        };
    }

    public static CompanyStakeholderCategory CopyToCompanyStakeholderCategory(this MasterTagCategory masterTagCategory)
    {
        return new CompanyStakeholderCategory()
        {
            MasterTagCategory = masterTagCategory,
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
        };
    }

    public static CompanyStakeholderTag CopyToCompanyStakeholderTag(this MasterTag masterTag,
        CompanyStakeholderCategory stakeholderCategory)
    {
        return new CompanyStakeholderTag()
        {
            MasterTag = masterTag,
            CompanyStakeholderCategory = stakeholderCategory,
            Name = masterTag.Name
        };
    }

    public static CompanySkillCategory CopyToCompanySkillCategory(this MasterTagCategory masterTagCategory)
    {
        return new CompanySkillCategory()
        {

            MasterTagCategory = masterTagCategory,
            Name = masterTagCategory.Name,
            Type = masterTagCategory.Type,
        };
    }


    public static CompanySkillTag CopyToCompanySkillTag(this MasterTag masterTag, CompanySkillCategory companySkillCategory)
    {
        return new CompanySkillTag()
        {
            MasterTag = masterTag,
            Name = masterTag.Name,
            CompanySkillCategory = companySkillCategory
        };
    }
}