using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTagCategories.Stakeholder;

public class CreateCompanyStakeholderCategoryCommand(ClaimsPrincipal user, ILogger logger, CompanyStakeholderCategoryDto category) : BaseCommand<CompanyStakeholderCategoryDto>(user, logger)
{
    public CompanyStakeholderCategoryDto Category { get; } = category;
}

public class CreateCompanyStakeholderCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<CreateCompanyStakeholderCategoryCommand, CompanyStakeholderCategoryDto>
{
    public async Task<CompanyStakeholderCategoryDto> Handle(CreateCompanyStakeholderCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company stakeholder category");
        
        var company = await Context.Companies.FirstOrDefaultAsync(x => x.UId == request.Category.Company!.UId, cancellationToken);

        MasterTagCategory? masterTagCategory = null;

        if (request.Category.MasterTagCategory != null)
        {
            masterTagCategory = await Context.MasterTagCategories.FirstOrDefaultAsync(x => x.UId == request.Category.MasterTagCategory.UId, cancellationToken);
        }
        
        var companyStakeholderCategory = new CompanyStakeholderCategory
        {
            Name = request.Category.Name,
            Type = request.Category.Type,
            Company = company!,
            MasterTagCategoryId = masterTagCategory?.Id
        };
        
        await Context.CompanyStakeholderCategories.AddAsync(companyStakeholderCategory, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        return Mapper.Map<CompanyStakeholderCategoryDto>(companyStakeholderCategory);
    }
}