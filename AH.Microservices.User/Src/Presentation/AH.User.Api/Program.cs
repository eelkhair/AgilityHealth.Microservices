using System.Diagnostics;
using AH.User.Api;
using AH.User.Api.ProgramExtensions;
using AH.User.Application;
using AH.User.Application.Dtos;
using AH.User.Infrastructure;
using AH.User.Persistence;
using AutoMapper;

const string appName = "AgilityHealth User Api";
const string appTag = "ah-user-api";

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices(appName, appTag);
builder.Services.AddHttpContextAccessor();

var mapper = new MapperConfiguration(c =>
{
    c.AddProfile(new MappingProfile());
    c.AddProfile(new ApiMappingProfileV1());
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddActors(_ =>
{
    // Example :  options.Actors.RegisterActor<MetadataActor>();
});

var app = builder.Build();

app.Initialize();


#if DEBUG
Debugger.Launch();
#endif

app.Run();