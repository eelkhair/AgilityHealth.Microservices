using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyStakeholderCategories;

public class ListCompanyStakeholderCategoriesQuery(ClaimsPrincipal user, ILogger logger, Guid companyUId)
    : BaseQuery<List<CompanyStakeholderCategoryDto>>(user, logger)
{
    public Guid CompanyUId { get; } = companyUId;
}

public class ListCompanyStakeholderCategoriesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanyStakeholderCategoriesQuery, List<CompanyStakeholderCategoryDto>>
{
    public async Task<List<CompanyStakeholderCategoryDto>> Handle(ListCompanyStakeholderCategoriesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company stakeholder categories");
        var companyStakeholderCategories = await Context.CompanyStakeholderCategories.Where(x=>x.Company.UId == request.CompanyUId).Select(x=> new CompanyStakeholderCategory()
        {
            UId = x.UId,
            Name = x.Name,
            Type = x.Type,
            Company = new Domain.Entities.Company
            {
                UId = x.Company.UId,
                Name = x.Company.Name
            },
            MasterTagCategory = new MasterTagCategory
            {
                UId = x.MasterTagCategory.UId,
                Name = x.MasterTagCategory.Name,
                Type = x.MasterTagCategory.Type,
                ClassName = x.MasterTagCategory.ClassName
            }
        }).ToListAsync(cancellationToken);
        return Mapper.Map<List<CompanyStakeholderCategoryDto>>(companyStakeholderCategories);
    }
}