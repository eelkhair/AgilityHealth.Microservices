using System.Reflection;
using AH.Shared.Application.Behaviors;
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

    }   
}