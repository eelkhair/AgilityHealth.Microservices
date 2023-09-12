using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AH.Metadata.Persistence;

public static class Seeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SurveyType>().HasData(
            new SurveyType { Id = 1, Name = "Team" , CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new SurveyType { Id = 2, Name = "Multi-Team", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new SurveyType { Id = 3, Name = "Individual", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new SurveyType { Id = 4, Name = "Organizational", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow},
            new SurveyType { Id = 5, Name = "Facilitator", CreatedBy = "System", UpdatedBy = "System", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );
    }
}