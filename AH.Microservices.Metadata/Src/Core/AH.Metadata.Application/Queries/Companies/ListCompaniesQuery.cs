using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Companies;

public class ListCompaniesQuery : BaseQuery<List<CompanyDto>>
{
    public ListCompaniesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListCompaniesQueryHandler : BaseQueryHandler, IRequestHandler<ListCompaniesQuery, List<CompanyDto>>
{
    public ListCompaniesQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<CompanyDto>> Handle(ListCompaniesQuery request, CancellationToken cancellationToken)
    {
        var countries = await Context.Companies.Include(x=>x.Domain).ToListAsync(cancellationToken);
        return Mapper.Map<List<CompanyDto>>(countries);
    }
}
