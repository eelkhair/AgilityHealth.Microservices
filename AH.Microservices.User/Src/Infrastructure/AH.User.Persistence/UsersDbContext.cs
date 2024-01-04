using System.Security.Claims;
using AH.Shared.Application.Extensions;
using AH.Shared.Domain.Constants;
using AH.Shared.Domain.Entities;
using AH.User.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace AH.User.Persistence;

public partial class UsersDbContext
{

}
public partial class UsersDbContext : DbContext, IUsersDbContext
{
    private readonly IConfiguration _configuration = null!;
    private readonly IHttpContextAccessor _contextAccessor = null!;
  

    public UsersDbContext(IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
    }

    public UsersDbContext()
    {
       
    }

    public UsersDbContext(string connectionString) : base(GetOptions(connectionString))
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
            ? connection.Replace(":", "")
            : _configuration.GetConnectionString("DefaultConnection");
            
            
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(connection!), x =>
        {
            x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Company");
        });

        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {                  
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
        modelBuilder.HasDefaultSchema("Users");
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
}
