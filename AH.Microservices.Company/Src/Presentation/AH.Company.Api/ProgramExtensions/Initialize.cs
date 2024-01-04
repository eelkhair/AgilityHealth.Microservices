using System.Diagnostics;
using AH.Company.Api.ProgramExtensions.Middleware;
using HealthChecks;
using HealthChecks.UI.Client;

namespace AH.Company.Api.ProgramExtensions;

internal static class AppConfig
{
    public static void Initialize(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(setup =>
        {
            setup.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 Docs");
            setup.OAuthClientId(app.Configuration["Auth0:ClientId"]);
            setup.OAuthClientSecret(app.Configuration["Auth0:ClientSecret"]);
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
        app.Use(async (context, next) =>
        {
            // Get the current span and its traceid
            var span = Activity.Current;
            var traceId = span?.TraceId.ToString();

            // Add the traceid to the response headers
            context.Response.Headers.Append("trace-id", traceId);

            // Call the next middleware in the pipeline
            await next();
        });
        app.UseCors("_myAllowSpecificOrigins");
        app.MapCustomHealthChecks("/healthzEndpoint", "/liveness", UIResponseWriter.WriteHealthCheckUIResponse);

    }
}