using AH.User.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AH.User.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>();
        services.AddScoped<IUsersDbContext, UsersDbContext>();
    }
}