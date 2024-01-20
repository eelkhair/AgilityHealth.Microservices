using System.Diagnostics;
using AH.Company.Api;
using AH.Company.Api.ProgramExtensions;
using AH.Company.Application;
using AH.Company.Application.Dtos;
using AH.Company.Persistence;
using AutoMapper;

const string appName = "AgilityHealth Company Api";
const string appTag = "ah-company-api";

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
