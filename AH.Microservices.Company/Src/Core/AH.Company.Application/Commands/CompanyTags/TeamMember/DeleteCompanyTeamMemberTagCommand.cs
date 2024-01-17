using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.TeamMember;

public class DeleteCompanyTeamMemberTagCommand(ClaimsPrincipal user, ILogger logger, Guid companyTeamMemberTagUId) : BaseCommand<bool>(user, logger)
{
    public Guid CompanyTeamMemberTagUId { get; } = companyTeamMemberTagUId;
}

public class DeleteCompanyTeamMemberTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanyTeamMemberTagCommand, bool>
{
    public async Task<bool> Handle(DeleteCompanyTeamMemberTagCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company team member tag");

        var companyTeamMemberTag = await Context.CompanyTeamMemberTags.FirstAsync(x => x.UId == request.CompanyTeamMemberTagUId, cancellationToken);

        Context.CompanyTeamMemberTags.Remove(companyTeamMemberTag);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return true;
    }
}