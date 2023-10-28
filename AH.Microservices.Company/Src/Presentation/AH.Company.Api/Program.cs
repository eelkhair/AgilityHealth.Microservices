using System.Diagnostics;
using System.Reflection;
using AH.Company.Api;
using AH.Company.Application;
using AH.Company.Application.Dtos;
using AH.Company.Domain.Constants;
using AH.Company.Persistence;
using AH.Shared.Api;
using AH.Shared.Api.Dtos;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

var swaggerConfig = new SwaggerDocSetup("AgilityHealth Company Api", PermissionDefinitions.GetPermissions(), xmlPath);
var auth0Config = new Auth0Configuration(
    builder.Configuration[$"Auth0:Domain"],
    builder.Configuration["Auth0:Audience"],
    builder.Configuration["Auth0:ClientId"],
    builder.Configuration["Auth0:ClientSecret"]
);

builder.Services.Build(swaggerConfig,auth0Config);

var mapper = new MapperConfiguration(c =>
{
    c.AddProfile(new MappingProfile());
    c.AddProfile(new ApiMappingProfileV1());
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddActors(_ =>
{
  // Example :  options.Actors.RegisterActor<MetadataActor>();
});

var app = builder.Build();

app.Initialize(auth0Config);

#if DEBUG
Debugger.Launch();
#endif

app.Run();
