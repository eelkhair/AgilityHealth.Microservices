using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.Companies;

public class ListCompaniesQuery(ClaimsPrincipal user, ILogger logger) : BaseQuery<List<CompanyDto>>(user, logger);

public class ListCompaniesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListCompaniesQuery, List<CompanyDto>>
{
    public async Task<List<CompanyDto>> Handle(ListCompaniesQuery request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting companies");
        var companies = await Context.Companies.ToListAsync(cancellationToken);
        return Mapper.Map<List<CompanyDto>>(companies);
    }
}