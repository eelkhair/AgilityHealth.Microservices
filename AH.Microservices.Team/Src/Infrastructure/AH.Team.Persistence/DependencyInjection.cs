using AH.Team.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Team.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TeamDbContext>();
        services.AddScoped<ITeamDbContext, TeamDbContext>();
    }
}