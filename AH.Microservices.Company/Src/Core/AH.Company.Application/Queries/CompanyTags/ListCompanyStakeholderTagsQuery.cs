using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTags;

public class ListCompanyStakeholdersQuery(ClaimsPrincipal user, ILogger logger, Guid companyStakeholderCategoryUId)
    : BaseQuery<List<CompanyStakeholderTagDto>>(user, logger)
{
    public Guid CompanyStakeholderCategoryUId { get; } = companyStakeholderCategoryUId;
}

public class ListCompanyStakeholdersQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanyStakeholdersQuery, List<CompanyStakeholderTagDto>>
{
    public async Task<List<CompanyStakeholderTagDto>> Handle(ListCompanyStakeholdersQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company stakeholder tags");
        var companyStakeholderTags = await Context.CompanyStakeholderTags
            .Where(x => x.CompanyStakeholderCategory.UId == request.CompanyStakeholderCategoryUId)
            .Select(x=> new CompanyStakeholderTag
            {
                Name = x.Name,
                MasterTag = x.MasterTag == null ? null : new MasterTag
                {
                    Name = x.MasterTag.Name,
                    ClassName = x.MasterTag.ClassName,
                    MasterTagCategory =  new MasterTagCategory
                    {
                        Name = x.MasterTag.MasterTagCategory.Name,
                        ClassName = x.MasterTag.MasterTagCategory.ClassName,
                        Type = x.MasterTag.MasterTagCategory.Type,
                        UId = x.MasterTag.MasterTagCategory.UId
                    },
                    UId = x.MasterTag.UId
                },
                CompanyStakeholderCategory = new CompanyStakeholderCategory
                {
                    Name = x.CompanyStakeholderCategory.Name,
                    Type = x.CompanyStakeholderCategory.Type,
                    UId = x.CompanyStakeholderCategory.UId,
                    Company = new Domain.Entities.Company
                    {
                      Name = x.CompanyStakeholderCategory.Company.Name,
                      UId = x.CompanyStakeholderCategory.Company.UId
                    },
                    MasterTagCategory = x.CompanyStakeholderCategory.MasterTagCategory == null ? null : new MasterTagCategory
                    {
                        Name = x.CompanyStakeholderCategory.MasterTagCategory.Name,
                        ClassName = x.CompanyStakeholderCategory.MasterTagCategory.ClassName,
                        Type = x.CompanyStakeholderCategory.MasterTagCategory.Type,
                        UId = x.CompanyStakeholderCategory.MasterTagCategory.UId
                    }
                },
                UId = x.UId
            }).ToListAsync(cancellationToken);

        return Mapper.Map<List<CompanyStakeholderTagDto>>(companyStakeholderTags);
    }
}