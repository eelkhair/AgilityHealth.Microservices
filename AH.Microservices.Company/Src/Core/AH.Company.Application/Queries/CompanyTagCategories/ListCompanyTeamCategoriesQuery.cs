using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTagCategories;

public class ListCompanyTeamCategoriesQuery(ClaimsPrincipal user, ILogger logger, Guid companyUId)
    : BaseQuery<List<CompanyTeamCategoryDto>>(user, logger)
{
    public Guid CompanyUId { get; } = companyUId;
}

public class ListCompanyTeamCategoriesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanyTeamCategoriesQuery, List<CompanyTeamCategoryDto>>
{
    public async Task<List<CompanyTeamCategoryDto>> Handle(ListCompanyTeamCategoriesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company team categories");
        var companyTeamCategories = await Context.CompanyTeamCategories.Where(x=>x.Company.UId == request.CompanyUId).Select(x=> new CompanyTeamCategory
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
        return Mapper.Map<List<CompanyTeamCategoryDto>>(companyTeamCategories);
    }
}