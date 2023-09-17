using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AH.Shared.Application.Extensions;
using AH.Shared.Domain.Constants;
using AH.Shared.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace AH.Company.Persistence;

public partial class CompanyMicroserviceDbContext
{
    public  DbSet<Domain.Entities.Company> Companies { get; set; } = null!;
    public  DbSet<MasterTagCategory> MasterTagCategories { get; set; } = null!;
    public  DbSet<MasterTag> MasterTags { get; set; } = null!;
    public  DbSet<CompanyTeamCategory> CompanyTeamCategories { get; set; } = null!;
    public  DbSet<CompanyTeamTag> CompanyTeamTags { get; set; } = null!;
    public  DbSet<CompanySkillCategory> CompanySkillCategories { get; set; } = null!;
    public  DbSet<CompanySkillTag> CompanySkillTags { get; set; } = null!;
    public  DbSet<CompanyStakeholderCategory> CompanyStakeholderCategories { get; set; } = null!;
    public  DbSet<CompanyStakeholderTag> CompanyStakeholderTags { get; set; } = null!;
    public  DbSet<CompanyTeamMemberCategory> CompanyTeamMemberCategories { get; set; } = null!;
    public  DbSet<CompanyTeamMemberTag> CompanyTeamMemberTags { get; set; } = null!;

}
public partial class CompanyMicroserviceDbContext : DbContext, ICompanyMicroServiceDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _contextAccessor;

    public CompanyMicroserviceDbContext(IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
    }
    public CompanyMicroserviceDbContext()
    {
        
    }
    
    public CompanyMicroserviceDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public CompanyMicroserviceDbContext(string connectionString) : base(GetOptions(connectionString))
    {
    }
    private static DbContextOptions GetOptions(string connectionString)
    {
        return new DbContextOptionsBuilder().UseSqlServer(connectionString)
            .Options;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        var fhh = _contextAccessor.HttpContext.Request.Headers["X-Forwarded-Host"].ToString();
        if (_contextAccessor.HttpContext.Request.Host.Host != "localhost" && !string.IsNullOrEmpty(fhh))
        {
            var key = fhh.Replace("apim-", "").Replace(".", "") + "company";
            connectionString = _configuration[key];
        }
        optionsBuilder.UseSqlServer(connectionString, x =>
        {
            x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Company");
        });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {                  
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyMicroserviceDbContext).Assembly);
        modelBuilder.HasDefaultSchema("Company");
        modelBuilder.SeedData();         
    }

    public Task<int> SaveChangesAsync(ClaimsPrincipal user)
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

        return base.SaveChangesAsync();
    }
}
