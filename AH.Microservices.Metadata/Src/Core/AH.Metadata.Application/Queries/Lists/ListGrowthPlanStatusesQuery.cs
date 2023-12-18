using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Lists;

public class ListGrowthPlanStatusesQuery: BaseQuery<List<GrowthPlanStatusDto>>
{
    public ListGrowthPlanStatusesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListGrowthPlanStatusesQueryHandler : BaseQueryHandler,
    IRequestHandler<ListGrowthPlanStatusesQuery, List<GrowthPlanStatusDto>>
{
    public ListGrowthPlanStatusesQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<GrowthPlanStatusDto>> Handle(ListGrowthPlanStatusesQuery request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting growth plan statuses");
        var growthPlanStatuses = await Context.GrowthPlanStatuses.ToListAsync(cancellationToken);
        return Mapper.Map<List<GrowthPlanStatusDto>>(growthPlanStatuses);
    }
}
