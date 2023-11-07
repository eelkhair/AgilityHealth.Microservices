using System.Diagnostics;
using System.Reflection;
using AH.Metadata.Api;
using AH.Metadata.Api.MessageSenders;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Persistence;
using AH.Shared.Api;
using AH.Shared.Api.Dtos;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

var swaggerConfig = new SwaggerDocSetup("AgilityHealth Metadata Api", PermissionDefinitions.GetPermissions(), xmlPath);
var auth0Config = new Auth0Configuration(
    builder.Configuration["Auth0:Domain"],
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

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddActors(_ =>
{
    // Example :  options.Actors.RegisterActor<MetadataActor>();
});

builder.Services.AddScoped<IMasterTagCategoriesMessageSender, MasterTagCategoriesMessageSender>();
builder.Services.AddScoped<IMasterTagsMessageSender, MasterTagsMessageSender>();

var app = builder.Build();
app.Initialize(auth0Config);

#if DEBUG
 Debugger.Launch();
#endif

app.Run();
