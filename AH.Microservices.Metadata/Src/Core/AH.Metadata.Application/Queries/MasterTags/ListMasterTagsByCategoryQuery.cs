using System.Security.Claims;
using AH.Metadata.Application.Commands;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTags;

public class ListMasterTagsByCategoryQuery : BaseCommand<List<MasterTagDto>>
{
    public Guid MasterCategoryUId { get; }

    public ListMasterTagsByCategoryQuery(ClaimsPrincipal user, ILogger logger, Guid masterCategoryUId) : base(user, logger)
    {
        MasterCategoryUId = masterCategoryUId;
    }
}

public class ListMasterTagsByCategoryQueryHandler : BaseCommandHandler, IRequestHandler<ListMasterTagsByCategoryQuery, List<MasterTagDto>>
{
    public ListMasterTagsByCategoryQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<MasterTagDto>> Handle(ListMasterTagsByCategoryQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting all master tags");
        var masterTags = await Context.MasterTags.Where(x => x.MasterTagCategory.UId == request.MasterCategoryUId).ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagDto>>(masterTags);
    }
}