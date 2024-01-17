using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.Skill;

public class DeleteCompanySkillTagCommand(ClaimsPrincipal user, ILogger logger, Guid tagUId)
    : BaseCommand<bool>(user, logger)
{
    public Guid TagUId { get; } = tagUId;
}

public class DeleteCompanySkillTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanySkillTagCommand, bool>
{
    public async Task<bool> Handle(DeleteCompanySkillTagCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company skill tag");

        var companySkillTag = await Context.CompanySkillTags
            .FirstAsync(x => x.UId == request.TagUId, cancellationToken);

        Context.CompanySkillTags.Remove(companySkillTag);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return true;
    }
}