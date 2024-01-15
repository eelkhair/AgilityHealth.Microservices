using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Stakeholder;

public class DeleteCompanyStakeholderCategoryCommand(ClaimsPrincipal user, ILogger logger, Guid categoryUId) : BaseCommand<Unit>(user, logger)
{
    public Guid CategoryUId { get; } = categoryUId;
}

public class DeleteCompanyStakeholderCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanyStakeholderCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCompanyStakeholderCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company stakeholder category");

        var companyStakeholderCategory = await Context.CompanyStakeholderCategories.FirstOrDefaultAsync(x => x.UId == request.CategoryUId, cancellationToken);
        Context.CompanyStakeholderCategories.Remove(companyStakeholderCategory!);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Unit.Value;
    }
}