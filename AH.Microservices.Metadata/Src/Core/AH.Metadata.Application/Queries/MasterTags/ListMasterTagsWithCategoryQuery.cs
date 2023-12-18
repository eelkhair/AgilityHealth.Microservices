using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTags;

public class ListMasterTagsWithCategoryQuery : BaseQuery<List<MasterTagDto>>
{
    public ListMasterTagsWithCategoryQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListMasterTagsWithCategoryQueryHandler : BaseQueryHandler, IRequestHandler<ListMasterTagsWithCategoryQuery, List<MasterTagDto>>
{
    public ListMasterTagsWithCategoryQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<MasterTagDto>> Handle(ListMasterTagsWithCategoryQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting all master tags");
        var masterTags = await Context.MasterTags.Include(x=> x.MasterTagCategory).ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagDto>>(masterTags);
    }
}