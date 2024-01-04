using AH.User.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AH.User.Application.Commands;

public abstract class BaseCommandHandler
{
    protected BaseCommandHandler(IUsersDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    protected IUsersDbContext Context { get; }
    protected IMapper Mapper { get; }
}