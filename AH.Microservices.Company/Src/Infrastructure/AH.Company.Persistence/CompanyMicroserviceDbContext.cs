using System.Security.Claims;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AH.Shared.Application.Extensions;
using AH.Shared.Domain.Constants;
using AH.Shared.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    private readonly IConfiguration _configuration = null!;
    private readonly IHttpContextAccessor _contextAccessor = null!;


    public CompanyMicroserviceDbContext(IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
    }

    public CompanyMicroserviceDbContext()
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
        if (optionsBuilder.IsConfigured) return;
        var connection =  _contextAccessor.HttpContext?.Request.Headers["Host"].ToString();
        connection = connection != null
            ? connection.Replace("ahcompany.", "").Replace(":","")
            : _configuration.GetConnectionString("DefaultConnection");
            
            
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(connection!), x =>
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

    public Task<int> SaveChangesAsync(ClaimsPrincipal user, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        // ReSharper disable once RedundantSuppressNullableWarningExpression
        foreach (var entry in ChangeTracker!.Entries<BaseAuditableEntity>())
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

    public void SetConnectionString(string domain)
    {
        domain = domain.Replace("127.0.0.1", "localhost").Replace(":", "");
        var connectionString = _configuration.GetConnectionString(domain);

        this.Database.SetConnectionString(connectionString);
    }
    
    public string? GetConnectionString()
    {
        return Database.GetConnectionString();
    }

    public override EntityEntry Update(object entity)
    {
        this.Entry(entity).State = EntityState.Modified;
        return base.Update(entity);
    }
}
