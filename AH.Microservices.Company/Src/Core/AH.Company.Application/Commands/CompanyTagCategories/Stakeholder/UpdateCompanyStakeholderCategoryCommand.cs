using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Stakeholder;

public class UpdateCompanyStakeholderCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanyStakeholderCategoryDto category) : BaseCommand<CompanyStakeholderCategoryDto>(user, logger)
{
    public CompanyStakeholderCategoryDto Category { get; } = category;
}

public class UpdateCompanyStakeholderCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<UpdateCompanyStakeholderCategoryCommand, CompanyStakeholderCategoryDto>
{
    public async Task<CompanyStakeholderCategoryDto> Handle(UpdateCompanyStakeholderCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company stakeholder category");
        
        var companyStakeholderCategory = await Context.CompanyStakeholderCategories.Include(x=>x.Company).FirstAsync(x => x.UId == request.Category.UId, cancellationToken);
      
        if (request.Category.MasterTagCategory != null)
        {
            var masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
            companyStakeholderCategory.MasterTagCategory = masterTagCategory;
        }

        companyStakeholderCategory.Name = request.Category.Name;
        companyStakeholderCategory.Type = request.Category.Type;
        
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        return Mapper.Map<CompanyStakeholderCategoryDto>(companyStakeholderCategory);
    }
}