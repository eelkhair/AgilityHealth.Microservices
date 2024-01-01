using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using AH.Web.Server.Middleware;
using AH.Web.Server.Services;
using AH.Web.Server.Services.Interfaces;
using Dapr.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IMasterTagCategoryService, MasterTagCategoryService>(
    p=> new MasterTagCategoryService(
        DaprClient.CreateInvokeHttpClient("ah-metadata-api"), 
         p.GetRequiredService<IHttpContextAccessor>()));

builder.Services.AddTransient<IMasterTagService, MasterTagService>(
    p=> new MasterTagService(
        DaprClient.CreateInvokeHttpClient("ah-metadata-api"), 
        p.GetRequiredService<IHttpContextAccessor>()));

builder.Services.AddTransient<IDomainService, DomainService>(
    p=> new DomainService(
        DaprClient.CreateInvokeHttpClient("ah-metadata-api"), 
        p.GetRequiredService<IHttpContextAccessor>()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
    {
        c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidAudience = builder.Configuration["Auth0:Audience"],
            ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}"
        };
        c.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var accessToken = context.SecurityToken as JwtSecurityToken;
                if (accessToken == null) return Task.CompletedTask;
                var client = context.HttpContext.RequestServices.GetService<IHttpClientFactory>()!.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.RawData);

                return Task.CompletedTask;
            }
                
        };
    });

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
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
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();