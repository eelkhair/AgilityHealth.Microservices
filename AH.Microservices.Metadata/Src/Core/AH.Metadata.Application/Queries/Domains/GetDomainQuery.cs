using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Domains;

public class GetDomainQuery: BaseQuery<DomainDto>
{
    public Guid DomainUid { get; }

    public GetDomainQuery(ClaimsPrincipal user, ILogger logger, Guid uid) : base(user, logger)
    {
        DomainUid = uid;
    }
}

public class GetDomainQueryHandler : BaseQueryHandler, IRequestHandler<GetDomainQuery, DomainDto>
{
    public GetDomainQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<DomainDto> Handle(GetDomainQuery request, CancellationToken cancellationToken)
    {
        var domain = await Context.Domains.FirstOrDefaultAsync(x => x.UId == request.DomainUid, cancellationToken);
        return Mapper.Map<DomainDto>(domain);
    }
}
