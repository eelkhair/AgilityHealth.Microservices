using System.Security.Claims;
using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AH.Metadata.Application.Interfaces;

public interface IMetadataDbContext
{
    DbSet<MasterTag> MasterTags { get; set; }
    DbSet<MasterTagCategory> MasterTagCategories { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Domain.Entities.Domain> Domains { get; set; }
    DbSet<GrowthPlanStatus> GrowthPlanStatuses { get; set; }
    DbSet<Industry> Industries { get; set; }
    DbSet<SurveyType> SurveyTypes { get; set; }
    ChangeTracker ChangeTracker { get;  }
    Task<int> SaveChangesAsync(ClaimsPrincipal user, CancellationToken cancellationToken);
}