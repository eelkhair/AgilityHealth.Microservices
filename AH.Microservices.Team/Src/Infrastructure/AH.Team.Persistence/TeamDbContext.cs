using System.Security.Claims;
using AH.Company.Persistence;
using AH.Team.Application.Extensions;
using AH.Team.Application.Interfaces;
using AH.Team.Domain.Constants;
using AH.Team.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace AH.Team.Persistence;

public partial class TeamDbContext
{

   
}
public partial class TeamDbContext : DbContext, ITeamDbContext
{
    private readonly IConfiguration _configuration = null!;
    private readonly IHttpContextAccessor _contextAccessor = null!;


    public TeamDbContext(IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
    }

    public TeamDbContext()
    {
       
    }

    public TeamDbContext(string connectionString) : base(GetOptions(connectionString))
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
        var connection = !string.IsNullOrEmpty(_contextAccessor.HttpContext?.Request.Headers["WebHost"].ToString())
            ? _contextAccessor.HttpContext.Request.Headers["WebHost"].ToString().Replace(":","")
            : !string.IsNullOrEmpty(_contextAccessor.HttpContext?.Request.Headers["Host"].ToString())
                ? _contextAccessor.HttpContext.Request.Headers["Host"].ToString().Replace("ahcompany-", "").Replace(":","")
                : _configuration.GetConnectionString("DefaultConnection");
            
            
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(connection!), x =>
        {
            x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Team");
        });

        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {                  
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeamDbContext).Assembly);
        modelBuilder.HasDefaultSchema("Team");
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
