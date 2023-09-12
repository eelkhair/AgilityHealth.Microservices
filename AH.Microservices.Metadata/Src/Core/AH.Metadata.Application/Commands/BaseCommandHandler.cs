using AH.Metadata.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AH.Metadata.Application.Commands;

public abstract class BaseCommandHandler
{
    protected BaseCommandHandler(IMetadataDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    protected IMetadataDbContext Context { get; }
    protected IMapper Mapper { get; }
}