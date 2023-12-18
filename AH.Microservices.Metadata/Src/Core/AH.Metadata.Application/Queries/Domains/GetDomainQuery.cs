using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
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
        var domain = await Context.Domains.Where(x => x.UId == request.DomainUid).Include(x=>x.Companies).FirstOrDefaultAsync(cancellationToken);
        return Mapper.Map<DomainDto>(domain);
    }
}