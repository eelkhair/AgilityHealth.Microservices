using AH.Company.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AH.Company.Application.Queries;

public abstract class BaseQueryHandler
{
    protected BaseQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected ICompanyMicroServiceDbContext Context { get; }
    protected IMapper Mapper { get; }
}