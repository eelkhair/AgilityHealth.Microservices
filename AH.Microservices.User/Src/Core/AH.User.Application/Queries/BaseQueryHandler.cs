using AH.User.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AH.User.Application.Queries;

public abstract class BaseQueryHandler
{
    protected BaseQueryHandler(IUsersDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }

    protected IUsersDbContext Context { get; }
    protected IMapper Mapper { get; }

}