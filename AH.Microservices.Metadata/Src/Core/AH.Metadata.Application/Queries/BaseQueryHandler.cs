using AH.Metadata.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AH.Metadata.Application.Queries;

public abstract class BaseQueryHandler
{
    protected BaseQueryHandler(IMetadataDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected IMetadataDbContext Context { get; }
    protected IMapper Mapper { get; }
}