using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.CompanyTeamTags;

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
        var companyTeamTags = await Context.CompanyTeamTags.Where(x=> x.CompanyTeamCategory.UId == request.CompanyTeamCategoryUId).Include(x=>x.MasterTag).ToListAsync(cancellationToken);
        return Mapper.Map<List<CompanyTeamTagDto>>(companyTeamTags);
    }
}