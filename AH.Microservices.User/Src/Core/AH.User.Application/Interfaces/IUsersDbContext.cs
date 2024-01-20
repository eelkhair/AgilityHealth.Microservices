using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AH.User.Application.Interfaces;

public interface IUsersDbContext
{
    DbSet<Domain.Entities.ApplicationUser> Users { get; set; }
    DbSet<Domain.Entities.ApplicationUserClaim> UserClaims { get; set; }
    ChangeTracker ChangeTracker { get; }
}