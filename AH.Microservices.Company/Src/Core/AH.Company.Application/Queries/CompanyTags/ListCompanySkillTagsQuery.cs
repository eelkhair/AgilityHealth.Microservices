using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTags;

public class ListCompanySkillsQuery(ClaimsPrincipal user, ILogger logger, Guid companySkillCategoryUId)
    : BaseQuery<List<CompanySkillTagDto>>(user, logger)
{
    public Guid CompanySkillCategoryUId { get; } = companySkillCategoryUId;
}

public class ListCompanySkillsQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompanySkillsQuery, List<CompanySkillTagDto>>
{
    public async Task<List<CompanySkillTagDto>> Handle(ListCompanySkillsQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company skill tags");
        var companySkillTags = await Context.CompanySkillTags
            .Where(x => x.CompanySkillCategory.UId == request.CompanySkillCategoryUId)
            .Select(x=> new CompanySkillTag
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
                CompanySkillCategory = new CompanySkillCategory
                {   
                    Name = x.CompanySkillCategory.Name,
                    Type = x.CompanySkillCategory.Type,
                    UId = x.CompanySkillCategory.UId,
                    MasterTagCategory = x.CompanySkillCategory.MasterTagCategory == null ? null : new MasterTagCategory
                    {
                        Name = x.CompanySkillCategory.MasterTagCategory.Name,
                        ClassName = x.CompanySkillCategory.MasterTagCategory.ClassName,
                        Type = x.CompanySkillCategory.MasterTagCategory.Type,
                        UId = x.CompanySkillCategory.MasterTagCategory.UId
                    },
                    Company = new Domain.Entities.Company
                    {
                        UId = x.CompanySkillCategory.Company.UId,
                        Name = x.CompanySkillCategory.Company.Name
                    }
                },
                UId = x.UId
            }).ToListAsync(cancellationToken);

        return Mapper.Map<List<CompanySkillTagDto>>(companySkillTags);
    }
}