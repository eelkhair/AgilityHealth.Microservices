using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Companies;

public class GetCompanyQuery : BaseQuery<CompanyDto>
{
    public Guid CompanyUId { get; }
    public GetCompanyQuery(ClaimsPrincipal user, ILogger logger, Guid uid) : base(user, logger)
    {
        CompanyUId = uid;
    }
}

public class GetCompanyQueryHandler : BaseQueryHandler, IRequestHandler<GetCompanyQuery, CompanyDto>
{
    public GetCompanyQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await Context.Companies.Include(x=>x.Domain).FirstOrDefaultAsync(x => x.UId == request.CompanyUId, cancellationToken);
        return Mapper.Map<CompanyDto>(company);
    }
}