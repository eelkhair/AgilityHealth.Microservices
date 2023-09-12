﻿using System.Security.Claims;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Entities;
using AH.Shared.Application.Extensions;
using AH.Shared.Domain.Constants;
using AH.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AH.Metadata.Persistence;

public partial class MetadataDbContext
{
    public DbSet<MasterTag> MasterTags { get; set; }
    public DbSet<MasterTagCategory> MasterTagCategories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Domain.Entities.Domain> Domains { get; set; }
    public DbSet<GrowthPlanStatus> GrowthPlanStatuses { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<SurveyType> SurveyTypes { get; set; }
}

public partial class MetadataDbContext : DbContext, IMetadataDbContext
{
    
    public MetadataDbContext()
    {
        
    }
    
    public MetadataDbContext(DbContextOptions options) : base(options)
    {
    }

    public MetadataDbContext(string connectionString) : base(GetOptions(connectionString))
    {
    }

    private static DbContextOptions GetOptions(string connectionString)
    {
        return new DbContextOptionsBuilder().UseSqlServer(connectionString)
            .Options;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetadataDbContext).Assembly);
        modelBuilder.HasDefaultSchema("Metadata");
        modelBuilder.SeedData();
    }

    public Task<int> SaveChangesAsync(ClaimsPrincipal user, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = now;
                    entry.Entity.CreatedBy = user.GetUserId();
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedBy = user.GetUserId();
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedBy = user.GetUserId();
                    break;
                case EntityState.Deleted:
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedBy = user.GetUserId();
                    entry.Entity.RecordStatus = RecordStatuses.Deleted;
                    entry.State = EntityState.Modified;
                    break;
            }

        return base.SaveChangesAsync(cancellationToken);
    }

}
