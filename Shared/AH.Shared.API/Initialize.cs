using AH.Shared.Api.Dtos;
using AH.Shared.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AH.Shared.Api;
public static class AppConfig
{
    public static void Initialize(this WebApplication app, Auth0Configuration configuration)
    {
        app.UseSwagger();
        app.UseSwaggerUI(setup =>
        {
            setup.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 Docs");
            setup.OAuthClientId(configuration.ClientId);
            setup.OAuthClientSecret(configuration.ClientSecret);
            setup.OAuthUsePkce();
        });
        if (!app.Environment.IsProduction())
        {
            app.UseDeveloperExceptionPage();
        }
        app.MapGet("/", (HttpResponse response ) =>
        {
            response.Redirect("swagger/index.html");
        }).ExcludeFromDescription();
       
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseCloudEvents();
        app.MapSubscribeHandler();
        app.MapControllers();
        app.MapActorsHandlers();
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseMiddleware<CorrelationIdMiddleware>();
    }
}