using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Skill;

public class DeleteCompanySkillCategoryCommand(ClaimsPrincipal user, ILogger logger, Guid categoryUId) : BaseCommand<Unit>(user, logger)
{
    public Guid CategoryUId { get; } = categoryUId;
}

public class DeleteCompanySkillCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<DeleteCompanySkillCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCompanySkillCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Deleting company stakeholder category");

        var companySkillCategory = await Context.CompanySkillCategories.FirstOrDefaultAsync(x => x.UId == request.CategoryUId, cancellationToken);
        Context.CompanySkillCategories.Remove(companySkillCategory!);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Unit.Value;
    }
}