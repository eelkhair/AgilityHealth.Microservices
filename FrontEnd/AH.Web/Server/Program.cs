using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using AH.Web.Server.Middleware;
using AH.Web.Server.Services;
using AH.Web.Server.Services.Implementations;
using AH.Web.Server.Services.Implementations.CategoriesAndTags;
using AH.Web.Server.Services.Interfaces;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Dapr.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

const string ahCompanyApi = "ah-company-api";
const string ahMetadataApi = "ah-metadata-api";

builder.Services.AddTransient<IMasterTagCategoryService, MasterTagCategoryService>(p=>  new MasterTagCategoryService(GetHttpClient(p, ahMetadataApi)));
builder.Services.AddTransient<IMasterTagService, MasterTagService>(p=>  new MasterTagService(GetHttpClient(p, ahMetadataApi)));
builder.Services.AddTransient<IDomainService, DomainService>(p=>  new DomainService(GetHttpClient(p, ahMetadataApi)));
builder.Services.AddTransient<ICompanyService, CompanyService>(p=> new CompanyService(
        GetHttpClient(p, ahMetadataApi),
    GetHttpClient(p, ahCompanyApi)));

builder.Services.AddTransient<ICompanyTeamCategoryService, CompanyTeamCategoryService>(p=> new CompanyTeamCategoryService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanyTeamMemberCategoryService, CompanyTeamMemberCategoryService>(p=> new CompanyTeamMemberCategoryService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanyStakeholderCategoryService, CompanyStakeholderCategoryService>(p=> new CompanyStakeholderCategoryService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanySkillCategoryService, CompanySkillCategoryService>(p=> new CompanySkillCategoryService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanyTeamTagService, CompanyTeamTagService>(p=> new CompanyTeamTagService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanyTeamMemberTagService, CompanyTeamMemberTagService>(p=> new CompanyTeamMemberTagService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanyStakeholderTagService, CompanyStakeholderTagService>(p=> new CompanyStakeholderTagService(
    GetHttpClient(p, ahCompanyApi)));
builder.Services.AddTransient<ICompanySkillTagService, CompanySkillTagService>(p=> new CompanySkillTagService(
    GetHttpClient(p, ahCompanyApi)));

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
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

HttpClient GetHttpClient(IServiceProvider services, string appId)
{
    var accessor = services.GetRequiredService<IHttpContextAccessor>();
    var httpClient = DaprClient.CreateInvokeHttpClient(appId);
    var token = accessor.HttpContext?.Request.Headers["Authorization"].ToString() ?? string.Empty;
    httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", string.Empty));

    if (accessor.HttpContext?.Request.Host.ToString() == string.Empty)
    {
        var referer = accessor.HttpContext?.Request.Headers["Referer"].FirstOrDefault();

        if (!string.IsNullOrEmpty(referer))
        {
            var uriValue = new Uri(referer);
            httpClient.DefaultRequestHeaders.Add("WebHost", uriValue.Host);

        }
    }
    else
    {
        httpClient.DefaultRequestHeaders.Add("WebHost", accessor.HttpContext?.Request.Host.ToString());

    }
    
    return httpClient;
}