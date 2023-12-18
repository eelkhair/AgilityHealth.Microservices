using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Lists;

public class ListCountriesQuery :BaseQuery<List<CountryDto>>
{
    public ListCountriesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListCountriesQueryHandler : BaseQueryHandler, IRequestHandler<ListCountriesQuery, List<CountryDto>>
{
    public ListCountriesQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<CountryDto>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting countries");
        var countries = await Context.Countries.ToListAsync(cancellationToken);
        return Mapper.Map<List<CountryDto>>(countries);
    }
}