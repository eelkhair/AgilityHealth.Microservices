using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.TeamMember;

public class DeleteCompanyTeamMemberCategoryCommand(ClaimsPrincipal user, ILogger logger, Guid categoryUId) : BaseCommand<Unit>(user, logger)
{
    public Guid CategoryUId { get; } = categoryUId;
}

public class DeleteCompanyTeamMemberCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanyTeamMemberCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCompanyTeamMemberCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company team member category");

        var companyTeamMemberCategory = await Context.CompanyTeamMemberCategories.FirstOrDefaultAsync(x => x.UId == request.CategoryUId, cancellationToken);
        Context.CompanyTeamMemberCategories.Remove(companyTeamMemberCategory!);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Unit.Value;
    }
}