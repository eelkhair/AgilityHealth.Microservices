using System.Security.Claims;
using AH.Metadata.Application.Commands;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTags;

public class GetMasterTagQuery : BaseCommand<MasterTagDto>
{
    public Guid MasterTagUId { get; }

    public GetMasterTagQuery(ClaimsPrincipal user, ILogger logger, Guid masterTagUId) : base(user, logger)
    {
        MasterTagUId = masterTagUId;
    }
}

public class GetMasterTagQueryHandler : BaseCommandHandler, IRequestHandler<GetMasterTagQuery, MasterTagDto>
{
    public GetMasterTagQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<MasterTagDto> Handle(GetMasterTagQuery request, CancellationToken cancellationToken)
    {
        var entity = await Context.MasterTags.FirstOrDefaultAsync(x => x.UId == request.MasterTagUId, cancellationToken);
        return Mapper.Map<MasterTagDto>(entity);
    }
}