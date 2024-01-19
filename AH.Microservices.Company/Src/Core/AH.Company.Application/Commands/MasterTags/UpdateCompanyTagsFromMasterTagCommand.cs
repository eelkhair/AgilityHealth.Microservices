using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class UpdateCompanyTagsFromMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag, MasterTagDto oldMasterTag, string domain) : BaseCommand<Unit>(user, logger)
{
    public MasterTagDto MasterTag { get; } = masterTag;
    public MasterTagDto OldMasterTag { get; } = oldMasterTag;
    public string Domain { get; } = domain;
}

public class UpdateCompanyTagsFromMasterTagCommandHandler(
    ICompanyMicroServiceDbContext context,
    IMapper mapper,
    ActivitySource activitySource) : BaseCommandHandler(context, mapper),
    IRequestHandler<UpdateCompanyTagsFromMasterTagCommand, Unit>
{
    private ActivitySource ActivitySource { get; } = activitySource;

    public async Task<Unit> Handle(UpdateCompanyTagsFromMasterTagCommand request,
        CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        request.Logger.LogInformation(
            "Creating company tags from master tag with name {Name} for domain {Domain}",
            request.MasterTag.Name, request.Domain);

        var activity = ActivitySource.StartActivity("UpdateCompanyTagsFromMasterTagCommandHandler",
            ActivityKind.Producer);
        activity?.SetTag("Domain", request.Domain);
        activity?.SetTag("Tag", request.MasterTag);
        activity?.SetTag("User", request.User.Identity?.Name);

        switch (request.MasterTag.ClassName)
        {
            case "MasterTeamTag":
                await UpdateCompanyTeamTag(request.MasterTag, request.OldMasterTag, cancellationToken);
                break;
            case "MasterStakeholderTag":
                await UpdateCompanyStakeholderTag(request.MasterTag, request.OldMasterTag, cancellationToken);
                break;
            case "MasterSkillsTag":
                await UpdateCompanySkillTag(request.MasterTag, request.OldMasterTag, cancellationToken);
                break;
            case "MasterTeamMemberTag":
                await UpdateCompanyTeamMemberTag(request.MasterTag, request.OldMasterTag, cancellationToken);
                break;
        }

        await Context.SaveChangesAsync(request.User, cancellationToken);
        activity?.Stop();
        return Unit.Value;
    }
    private async Task UpdateCompanyTeamMemberTag(MasterTagDto masterTag, MasterTagDto oldMasterTag, CancellationToken cancellationToken)
    {
        var companyTeamMemberTags = await Context.CompanyTeamMemberTags.Include(x=> x.CompanyTeamMemberCategory)
            .Where(x => x.MasterTagId == oldMasterTag.Id && x.Name == oldMasterTag.Name )
            .ToListAsync(cancellationToken);

        Dictionary<int, int> teamTags = new();
        if (masterTag.ParentMasterTag != null)
        {
            teamTags = await Context.CompanyTeamTags.Include(x=>x.CompanyTeamCategory)
                .Where(x => x.MasterTag != null && x.MasterTag.UId == masterTag.ParentMasterTag.UId && x.Name == masterTag.ParentMasterTag.Name)
                .ToDictionaryAsync(x => x.Id, y => y.CompanyTeamCategory.CompanyId, cancellationToken: cancellationToken);
        }

        companyTeamMemberTags.ForEach(c =>
        {
            c.Name = masterTag.Name;
            
            var teamTag = teamTags.FirstOrDefault(x => x.Value == c.CompanyTeamMemberCategory.CompanyId);
            if (teamTag.Key != 0)
            {
                c.CompanyTeamTagId = teamTag.Key;
            }
            else
            {
                c.CompanyTeamTagId = null;
            }
            Context.Update(c);
        });
    }
    private async Task UpdateCompanyStakeholderTag(MasterTagDto masterTag, MasterTagDto oldMasterTag, CancellationToken cancellationToken)
    {
        var companyStakeholderTags = await Context.CompanyStakeholderTags
            .Where(x => x.MasterTagId == oldMasterTag.Id && x.Name == oldMasterTag.Name )
            .ToListAsync(cancellationToken);

      

        companyStakeholderTags.ForEach(c =>
        {
            c.Name = masterTag.Name;
            Context.Update(c);
        });
    }

    private async Task UpdateCompanyTeamTag(MasterTagDto masterTag, MasterTagDto oldMasterTag, CancellationToken cancellationToken)
    {
        var companyTeamTags = await Context.CompanyTeamTags.Include(x=>x.CompanyTeamCategory)
            .Where(x => x.MasterTagId == oldMasterTag.Id && x.Name == oldMasterTag.Name )
            .ToListAsync(cancellationToken);

        companyTeamTags.ForEach(c =>
        {
            c.Name = masterTag.Name;
            Context.Update(c);
        });
    }
    
    private async Task UpdateCompanySkillTag(MasterTagDto masterTag, MasterTagDto oldMasterTag, CancellationToken cancellationToken)
    {
        var companySkillTags = await Context.CompanySkillTags
            .Where(x => x.MasterTagId == oldMasterTag.Id && x.Name == oldMasterTag.Name )
            .ToListAsync(cancellationToken);

        companySkillTags.ForEach(c =>
        {
            c.Name = masterTag.Name;
            Context.Update(c);
        });
    }
}