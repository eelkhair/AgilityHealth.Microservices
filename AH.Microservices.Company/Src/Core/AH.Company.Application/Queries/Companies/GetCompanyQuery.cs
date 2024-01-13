using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.Companies;

public class GetCompanyQuery(ClaimsPrincipal user, ILogger logger, Guid companyUId)
    : BaseQuery<CompanyDto>(user, logger)
{
    public Guid CompanyUId { get; set; } = companyUId;
}

public class GetCompanyQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<GetCompanyQuery, CompanyDto>
{
    public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting company with uid: {CompanyUId}", request.CompanyUId);
        var company = await Context.Companies.FirstOrDefaultAsync(x => x.UId == request.CompanyUId, cancellationToken);
        return Mapper.Map<CompanyDto>(company);
    }
}