using AH.Company.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Company.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CompanyMicroserviceDbContext>();
        services.AddScoped<ICompanyMicroServiceDbContext, CompanyMicroserviceDbContext>();
    }
}