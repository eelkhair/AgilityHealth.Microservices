using System.Diagnostics;
using AH.Metadata.Api;
using AH.Metadata.Api.MessageSenders;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Api.ProgramExtensions;
using AH.Metadata.Application;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Persistence;
using AutoMapper;


const string appName = "AgilityHealth Metadata Api";
const string appTag = "ah-metadata-api";

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddScoped<IMasterTagCategoriesMessageSender, MasterTagCategoriesMessageSender>();
builder.Services.AddScoped<IMasterTagsMessageSender, MasterTagsMessageSender>();
builder.Services.AddScoped<ICompaniesMessageSender, CompaniesMessageSender>();

var app = builder.Build();
app.Initialize();

#if DEBUG
 Debugger.Launch();
#endif

app.Run();
