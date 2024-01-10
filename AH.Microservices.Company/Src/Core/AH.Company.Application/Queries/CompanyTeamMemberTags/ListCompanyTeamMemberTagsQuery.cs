using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTeamMemberTags;

public class ListCompanyTeamMemberTagsQuery(ClaimsPrincipal user, ILogger logger, Guid companyTeamMemberCategoryUId)
    : BaseQuery<List<CompanyTeamMemberTagDto>>(user, logger)
{
    public Guid CompanyTeamMemberCategoryUId { get; } = companyTeamMemberCategoryUId;
}

public class ListCompanyTeamMemberTagsQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanyTeamMemberTagsQuery, List<CompanyTeamMemberTagDto>>
{
    public async Task<List<CompanyTeamMemberTagDto>> Handle(ListCompanyTeamMemberTagsQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company team member tags");

        var companyTeamMemberTags = await Context.CompanyTeamMemberTags
            .Where(x => x.CompanyTeamMemberCategory.UId == request.CompanyTeamMemberCategoryUId)
            .Select(x=> new CompanyTeamMemberTag
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
                CompanyTeamTag = x.CompanyTeamTag == null ? null : new CompanyTeamTag
                {
                    Name = x.CompanyTeamTag.Name,
                    MasterTag = x.CompanyTeamTag.MasterTag == null ? null : new MasterTag
                    {
                        Name = x.CompanyTeamTag.MasterTag.Name,
                        ClassName = x.CompanyTeamTag.MasterTag.ClassName,
                        MasterTagCategory =  new MasterTagCategory
                        {
                            Name = x.CompanyTeamTag.MasterTag.MasterTagCategory.Name,
                            ClassName = x.CompanyTeamTag.MasterTag.MasterTagCategory.ClassName,
                            Type = x.CompanyTeamTag.MasterTag.MasterTagCategory.Type,
                            UId = x.CompanyTeamTag.MasterTag.MasterTagCategory.UId
                        },
                        UId = x.CompanyTeamTag.MasterTag.UId
                    },
                    UId = x.CompanyTeamTag.UId
                },
                UId = x.UId
            }).ToListAsync(cancellationToken);
        
        return Mapper.Map<List<CompanyTeamMemberTagDto>>(companyTeamMemberTags);
    }
}