using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Domains;

public class ListDomainsQuery : BaseQuery<List<DomainDto>>
{
    public ListDomainsQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
    
}

public class ListDomainsQueryHandler : BaseQueryHandler, IRequestHandler<ListDomainsQuery, List<DomainDto>>
{
    public ListDomainsQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<DomainDto>> Handle(ListDomainsQuery request, CancellationToken cancellationToken)
    {
        var domains = await Context.Domains.Include(x=>x.Companies).ToListAsync(cancellationToken);
        var results = Mapper.Map<List<DomainDto>>(domains);
        
        return results;
    }
}