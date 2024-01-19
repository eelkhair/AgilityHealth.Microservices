using System.Diagnostics;
using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class DeleteCompanyTagsFromMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag, string domain) : BaseCommand<Unit>(user, logger)
{
    public MasterTagDto MasterTag { get; } = masterTag;
    public string Domain { get; } = domain;
}

public class DeleteCompanyTagsFromMasterTagCommandHandler(
    ICompanyMicroServiceDbContext context,
    IMapper mapper,
    ActivitySource activitySource) : BaseCommandHandler(context, mapper),
    IRequestHandler<DeleteCompanyTagsFromMasterTagCommand, Unit>
{
    private ActivitySource ActivitySource { get; } = activitySource;

    public async Task<Unit> Handle(DeleteCompanyTagsFromMasterTagCommand request,
        CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        request.Logger.LogInformation(
            "Creating company tags from master tag with name {Name} for domain {Domain}",
            request.MasterTag.Name, request.Domain);

        var activity = ActivitySource.StartActivity("DeleteCompanyTagsFromMasterTagCommandHandler",
            ActivityKind.Producer);
        activity?.SetTag("Domain", request.Domain);
        activity?.SetTag("Tag", request.MasterTag);
        activity?.SetTag("User", request.User.Identity?.Name);

        switch (request.MasterTag.ClassName)
        {
            case "MasterTeamTag":
                await DeleteCompanyTeamTag(request.MasterTag, cancellationToken);
                break;
            case "MasterStakeholderTag":
                await DeleteCompanyStakeholderTag(request.MasterTag, cancellationToken);
                break;
            case "MasterSkillsTag":
                await DeleteCompanySkillTag(request.MasterTag, cancellationToken);
                break;
            case "MasterTeamMemberTag":
                await DeleteCompanyTeamMemberTag(request.MasterTag, cancellationToken);
                break;
        }

        await Context.SaveChangesAsync(request.User, cancellationToken);
        activity?.Stop();
        return Unit.Value;
    }

    private async Task DeleteCompanyTeamMemberTag(MasterTagDto masterTag, CancellationToken cancellationToken)
    {
        var companyTeamMemberTags = await Context.CompanyTeamMemberTags
            .Where(x => x.MasterTagId == masterTag.Id && x.Name == masterTag.Name )
            .ToListAsync(cancellationToken);
        
        Context.CompanyTeamMemberTags.RemoveRange(companyTeamMemberTags);

    }

    private async Task DeleteCompanySkillTag(MasterTagDto masterTag, CancellationToken cancellationToken)
    {
        var companySkillTags = await Context.CompanySkillTags.Include(x=> x.CompanySkillCategory)
            .Where(x => x.MasterTagId == masterTag.Id && x.Name == masterTag.Name )
            .ToListAsync(cancellationToken);
        
        Context.CompanySkillTags.RemoveRange(companySkillTags);
    }

    private async Task DeleteCompanyStakeholderTag(MasterTagDto masterTag, CancellationToken cancellationToken)
    {
        var companyStakeholderTags = await Context.CompanyStakeholderTags.Include(x=> x.CompanyStakeholderCategory)
            .Where(x => x.MasterTagId == masterTag.Id && x.Name == masterTag.Name )
            .ToListAsync(cancellationToken);
        
        Context.CompanyStakeholderTags.RemoveRange(companyStakeholderTags);
    }

    private async Task DeleteCompanyTeamTag(MasterTagDto masterTag, CancellationToken cancellationToken)
    {
        var companyTeamTags = await Context.CompanyTeamTags.Include(x=> x.CompanyTeamCategory)
            .Where(x => x.MasterTagId == masterTag.Id && x.Name == masterTag.Name )
            .ToListAsync(cancellationToken);
        
        Context.CompanyTeamTags.RemoveRange(companyTeamTags);
    }
}