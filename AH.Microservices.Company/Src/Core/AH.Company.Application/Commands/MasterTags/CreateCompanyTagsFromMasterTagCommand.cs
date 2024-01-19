using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class CreateCompanyTagsFromMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag, string domain) : BaseCommand<Unit>(user, logger)
{
    public MasterTagDto MasterTag { get; } = masterTag;
    public string Domain { get; } = domain;
}

public class CreateCompanyTagsFromMasterTagCommandHandler(
    ICompanyMicroServiceDbContext context,
    IMapper mapper,
    ActivitySource activitySource) : BaseCommandHandler(context, mapper),
    IRequestHandler<CreateCompanyTagsFromMasterTagCommand, Unit>
{
    private ActivitySource ActivitySource { get; } = activitySource;

    public async Task<Unit> Handle(CreateCompanyTagsFromMasterTagCommand request,
        CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        request.Logger.LogInformation(
            "Creating company tags from master tag with name {Name} for domain {Domain}",
            request.MasterTag.Name, request.Domain);

        var activity = ActivitySource.StartActivity("CreateCompanyTagsFromMasterTagCommandHandler",
            ActivityKind.Producer);
        activity?.SetTag("Domain", request.Domain);
        activity?.SetTag("Tag", request.MasterTag);
        activity?.SetTag("User", request.User.Identity?.Name);

        switch (request.MasterTag.ClassName)
        {
            case "MasterTeamTag":
                await CreateCompanyTeamTag(request.MasterTag, cancellationToken);
                break;
            case "MasterStakeholderTag":
                await CreateCompanyStakeholderTag(request.MasterTag, cancellationToken);
                break;
            case "MasterSkillsTag":
                await CreateCompanySkillTag(request.MasterTag, cancellationToken);
                break;
            case "MasterTeamMemberTag":
                await CreateCompanyTeamMemberTag(request.MasterTag, cancellationToken);
                break;
        }
        await Context.SaveChangesAsync(request.User, cancellationToken);
        activity?.Stop();
        return Unit.Value;
    }

    private async Task CreateCompanyTeamMemberTag(MasterTagDto requestMasterTag, CancellationToken cancellationToken)
    {
        var categories = await Context.CompanyTeamMemberCategories
            .Where(x => x.MasterTagCategory != null &&  x.MasterTagCategory.UId == requestMasterTag.MasterTagCategory.UId && x.Name == requestMasterTag.MasterTagCategory.Name).ToListAsync(cancellationToken);

        Dictionary<int, int> teamTags = new();
        if (requestMasterTag.ParentMasterTag != null)
        {
            teamTags = await Context.CompanyTeamTags.Include(x=>x.CompanyTeamCategory)
                .Where(x => x.MasterTag != null && x.MasterTag.UId == requestMasterTag.ParentMasterTag.UId && x.Name == requestMasterTag.ParentMasterTag.Name)
                .ToDictionaryAsync(x => x.Id, y => y.CompanyTeamCategory.CompanyId, cancellationToken: cancellationToken);
        }

        categories.ForEach(category =>
        {
            var companyTeamMemberTag = new CompanyTeamMemberTag
            {
                Name = requestMasterTag.Name,
                CompanyTeamMemberCategoryId = category.Id,
                MasterTagId = requestMasterTag.Id
            };
            var teamTag = teamTags.FirstOrDefault(x => x.Value == category.CompanyId);
            if (teamTag.Key != 0)
            {
                companyTeamMemberTag.CompanyTeamTagId = teamTag.Key;
            }
            
            Context.CompanyTeamMemberTags.Add(companyTeamMemberTag);
        });
    }

    private async Task CreateCompanySkillTag(MasterTagDto requestMasterTag, CancellationToken cancellationToken)
    {
        var categories = await Context.CompanySkillCategories
            .Where(x => x.MasterTagCategory != null &&  x.MasterTagCategory.UId == requestMasterTag.MasterTagCategory.UId).ToListAsync(cancellationToken);
        
        categories.ForEach(category =>
        {
            var companySkillTag = new CompanySkillTag
            {
                Name = requestMasterTag.Name,
                CompanySkillCategoryId = category.Id,
                MasterTagId = requestMasterTag.Id
            };
            
            Context.CompanySkillTags.Add(companySkillTag);
        });
    }
  

    private async Task CreateCompanyStakeholderTag(MasterTagDto requestMasterTag, CancellationToken cancellationToken)
    {
        var categories = await Context.CompanyStakeholderCategories
            .Where(x => x.MasterTagCategory != null &&  x.MasterTagCategory.UId == requestMasterTag.MasterTagCategory.UId).ToListAsync(cancellationToken);

        categories.ForEach(category =>
        {
            var companyStakeholderTag = new CompanyStakeholderTag
            {
                Name = requestMasterTag.Name,
                CompanyStakeholderCategoryId = category.Id,
                MasterTagId = requestMasterTag.Id
            };

            Context.CompanyStakeholderTags.Add(companyStakeholderTag);
        });
    }

    private async Task CreateCompanyTeamTag(MasterTagDto requestMasterTag, CancellationToken cancellationToken)
    {
        var categories = await Context.CompanyTeamCategories
            .Where(x => x.MasterTagCategory != null &&  x.MasterTagCategory.UId == requestMasterTag.MasterTagCategory.UId).ToListAsync(cancellationToken);
        
        categories.ForEach(category =>
        {
            var companyTeamTag = new CompanyTeamTag
            {
                Name = requestMasterTag.Name,
                CompanyTeamCategoryId = category.Id,
                MasterTagId = requestMasterTag.Id
            };
            
            Context.CompanyTeamTags.Add(companyTeamTag);
        });
    }
}