using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTags;

public class ListMasterTagsQuery : BaseQuery<List<MasterTagDto>>
{
    public ListMasterTagsQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListMasterTagsQueryHandler : BaseQueryHandler, IRequestHandler<ListMasterTagsQuery, List<MasterTagDto>>
{
    public ListMasterTagsQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<MasterTagDto>> Handle(ListMasterTagsQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting all master tags");
        var masterTags = await Context.MasterTags.ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagDto>>(masterTags);
    }
}