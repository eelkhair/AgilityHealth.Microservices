using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTagCategories;

public class ListCompanySkillCategoriesQuery(ClaimsPrincipal user, ILogger logger, Guid companyUId)
    : BaseQuery<List<CompanySkillCategoryDto>>(user, logger)
{
    public Guid CompanyUId { get; } = companyUId;
}

public class ListCompanySkillCategoriesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanySkillCategoriesQuery, List<CompanySkillCategoryDto>>
{
    public async Task<List<CompanySkillCategoryDto>> Handle(ListCompanySkillCategoriesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company skill categories");
        var companySkillCategories = await Context.CompanySkillCategories
            .Where(x=>x.Company.UId == request.CompanyUId)
            .Select(x=> new CompanySkillCategory
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
        return Mapper.Map<List<CompanySkillCategoryDto>>(companySkillCategories);
    }
}