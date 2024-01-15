using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTagCategories;

public class ListCompanyTeamMemberCategoriesQuery(ClaimsPrincipal user, ILogger logger, Guid companyUId)
    : BaseQuery<List<CompanyTeamMemberCategoryDto>>(user, logger)
{
    public Guid CompanyUId { get; } = companyUId;
}

public class ListCompanyTeamMemberCategoriesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanyTeamMemberCategoriesQuery, List<CompanyTeamMemberCategoryDto>>
{
    public async Task<List<CompanyTeamMemberCategoryDto>> Handle(ListCompanyTeamMemberCategoriesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company team member categories");
        var companyTeamMemberCategories = await Context.CompanyTeamMemberCategories.Where(x=>x.Company.UId == request.CompanyUId).Select(x=> new CompanyTeamMemberCategory
        {
            UId = x.UId,
            Name = x.Name,
            Type = x.Type,
            Company = new Domain.Entities.Company
            {
                UId = x.Company.UId,
                Name = x.Company.Name
            },
            MasterTagCategory = x.MasterTagCategory != null ? new MasterTagCategory
            {
                UId = x.MasterTagCategory.UId,
                Name = x.MasterTagCategory.Name,
                Type = x.MasterTagCategory.Type,
                ClassName = x.MasterTagCategory.ClassName
            } : null
        }).ToListAsync(cancellationToken);
        return Mapper.Map<List<CompanyTeamMemberCategoryDto>>(companyTeamMemberCategories);
    }
}