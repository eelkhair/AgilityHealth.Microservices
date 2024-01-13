using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTags;

public class ListCompanyTeamTagsQuery(ClaimsPrincipal user, ILogger logger, Guid companyTeamCategoryUId)
    : BaseQuery<List<CompanyTeamTagDto>>(user, logger)
{
    public Guid CompanyTeamCategoryUId { get; } = companyTeamCategoryUId;
}

public class ListCompanyTeamTagsQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanyTeamTagsQuery, List<CompanyTeamTagDto>>
{
    public async Task<List<CompanyTeamTagDto>> Handle(ListCompanyTeamTagsQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company team tags");
        var companyTeamTags = await Context.CompanyTeamTags
            .Where(x => x.CompanyTeamCategory.UId == request.CompanyTeamCategoryUId)
            .Select(x=> new CompanyTeamTag
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
                CompanyTeamCategory = new CompanyTeamCategory
                {
                    Name = x.CompanyTeamCategory.Name,
                    Type = x.CompanyTeamCategory.Type,
                    UId = x.CompanyTeamCategory.UId,
                    Company = new Domain.Entities.Company
                    {
                        Name = x.CompanyTeamCategory.Company.Name,
                        UId = x.CompanyTeamCategory.Company.UId
                    },
                    MasterTagCategory = new MasterTagCategory
                    {
                        Name = x.CompanyTeamCategory.MasterTagCategory.Name,
                        ClassName = x.CompanyTeamCategory.MasterTagCategory.ClassName,
                        Type = x.CompanyTeamCategory.MasterTagCategory.Type,
                        UId = x.CompanyTeamCategory.MasterTagCategory.UId
                    }
                },
                UId = x.UId
            }).ToListAsync(cancellationToken);

        return Mapper.Map<List<CompanyTeamTagDto>>(companyTeamTags);
    }
}