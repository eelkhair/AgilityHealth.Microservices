using System.Diagnostics;
using AH.Team.Api;
using AH.Team.Api.ProgramExtensions;
using AH.Team.Application;
using AH.Team.Application.Dtos;
using AH.Team.Persistence;
using AutoMapper;


const string appName = "AgilityHealth Team Api";
const string appTag = "ah-team-api";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.ConfigureServices(appName, appTag);

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
var app = builder.Build();

app.Initialize();


#if DEBUG
Debugger.Launch();
#endif

app.Run();
