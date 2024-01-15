using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Team;

public class DeleteCompanyTeamCategoryCommand(ClaimsPrincipal user, ILogger logger, Guid categoryUId) : BaseCommand<Unit>(user, logger)
{
    public Guid CategoryUId { get; } = categoryUId;
}

public class DeleteCompanyTeamCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanyTeamCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCompanyTeamCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company team category");

        var companyTeamCategory = await Context.CompanyTeamCategories.FirstOrDefaultAsync(x => x.UId == request.CategoryUId, cancellationToken);
        Context.CompanyTeamCategories.Remove(companyTeamCategory!);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Unit.Value;
    }
}