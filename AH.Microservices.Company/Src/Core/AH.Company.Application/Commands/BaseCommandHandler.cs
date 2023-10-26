using AH.Company.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands;

public abstract class BaseCommandHandler
{
    protected BaseCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }
    protected ICompanyMicroServiceDbContext Context { get; }
    protected IMapper Mapper { get; }
    
    protected void SetConnectionString(string domain, ILogger logger)
    {
        Context.SetConnectionString(domain);
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        
        logger.LogInformation("Connection string set to {ConnectionString}", Context.GetConnectionString());
    }
}