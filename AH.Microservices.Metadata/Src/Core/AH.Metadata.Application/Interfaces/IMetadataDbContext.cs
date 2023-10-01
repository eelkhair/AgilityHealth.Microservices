using System.Security.Claims;
using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AH.Metadata.Application.Interfaces;

public interface IMetadataDbContext
{
    DbSet<MasterTag> MasterTags { get; set; }
    DbSet<MasterTagCategory> MasterTagCategories { get; set; }
    DbSet<Company> Companies { get; }
    DbSet<Country> Countries { get; }
    DbSet<Domain.Entities.Domain> Domains { get; }
    DbSet<GrowthPlanStatus> GrowthPlanStatuses { get; }
    DbSet<Industry> Industries { get; }
    DbSet<SurveyType> SurveyTypes { get; }
    ChangeTracker ChangeTracker { get;  }
    Task<int> SaveChangesAsync(ClaimsPrincipal user, CancellationToken cancellationToken);
}