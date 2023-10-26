using System.Security.Claims;
using AH.Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AH.Company.Application.Interfaces;

public interface ICompanyMicroServiceDbContext
{
    DbSet<Domain.Entities.Company> Companies { get; set; }
    DbSet<MasterTagCategory> MasterTagCategories { get; set; }
    DbSet<MasterTag> MasterTags { get; set; }
    DbSet<CompanyTeamCategory> CompanyTeamCategories { get; set; }
    DbSet<CompanyTeamTag> CompanyTeamTags { get; set; }
    DbSet<CompanySkillCategory> CompanySkillCategories { get; set; }
    DbSet<CompanySkillTag> CompanySkillTags { get; set; }
    DbSet<CompanyStakeholderCategory> CompanyStakeholderCategories { get; set; }
    DbSet<CompanyStakeholderTag> CompanyStakeholderTags { get; set; }
    DbSet<CompanyTeamMemberCategory> CompanyTeamMemberCategories { get; set; }
    DbSet<CompanyTeamMemberTag> CompanyTeamMemberTags { get; set; }
    ChangeTracker ChangeTracker { get; set; }
    Task<int> SaveChangesAsync(ClaimsPrincipal user);
    void SetConnectionString(string domain);
    string? GetConnectionString();
}