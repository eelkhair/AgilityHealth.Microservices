using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.Team;

public class DeleteCompanyTeamTagCommand(ClaimsPrincipal user, ILogger logger, Guid tagUId) : BaseCommand<Unit>(user, logger)
{
    public Guid TagUId { get; } = tagUId;
}

public class DeleteCompanyTeamTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanyTeamTagCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCompanyTeamTagCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company team tag");

        var companyTeamTag = await Context.CompanyTeamTags.FirstAsync(x => x.UId == request.TagUId, cancellationToken);
        Context.CompanyTeamTags.Remove(companyTeamTag);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Unit.Value;
    }
}