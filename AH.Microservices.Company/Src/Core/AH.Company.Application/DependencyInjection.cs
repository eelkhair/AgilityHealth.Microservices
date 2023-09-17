using System.Reflection;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AH.Company.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            configuration => configuration.RegisterServicesFromAssembly(Assembly.GetCallingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<ICompanyMicroServiceDbContext>();
    }   
}