using AH.Company.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AH.Company.Application.Queries;

public abstract class BaseQueryHandler
{
    protected BaseQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        Context.SetConnectionString(httpContextAccessor?.HttpContext?.Request.Headers.Host!);
    }

    protected ICompanyMicroServiceDbContext Context { get; }
    protected IMapper Mapper { get; }

}