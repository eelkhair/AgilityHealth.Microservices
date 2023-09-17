using AH.Company.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AH.Company.Application.Commands;

public abstract class BaseCommandHandler
{
    protected BaseCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    protected ICompanyMicroServiceDbContext Context { get; }
    protected IMapper Mapper { get; }
}