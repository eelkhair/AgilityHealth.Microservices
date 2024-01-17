using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.Stakeholder;

public class DeleteCompanyStakeholderTagCommand(ClaimsPrincipal user, ILogger logger, Guid tagUId)
    : BaseCommand<bool>(user, logger)
{
    public Guid TagUId { get; } = tagUId;
}

public class DeleteCompanyStakeholderTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanyStakeholderTagCommand, bool>
{
    public async Task<bool> Handle(DeleteCompanyStakeholderTagCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company stakeholder tag");

        var companyStakeholderTag = await Context.CompanyStakeholderTags
            .FirstAsync(x => x.UId == request.TagUId, cancellationToken);

        Context.CompanyStakeholderTags.Remove(companyStakeholderTag);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return true;
    }
}