using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Lists;

public class ListIndustriesQuery : BaseQuery<List<IndustryDto>>
{
    public ListIndustriesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
    
    
}

public class ListIndustriesQueryHandler : BaseQueryHandler, IRequestHandler<ListIndustriesQuery, List<IndustryDto>>
{
    public ListIndustriesQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<IndustryDto>> Handle(ListIndustriesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting industries");
        var industries = await Context.Industries.ToListAsync(cancellationToken);
        return Mapper.Map<List<IndustryDto>>(industries);
    }
}
