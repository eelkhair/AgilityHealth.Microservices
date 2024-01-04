using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AH.User.Application.Interfaces;

public interface IUsersDbContext
{
    ChangeTracker ChangeTracker { get; }
}