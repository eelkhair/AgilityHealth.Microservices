using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;
using AH.Metadata.Api;
using AH.Metadata.Api.Configuration.Middleware;
using AH.Metadata.Api.MessageSenders;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Persistence;
using AH.Shared.Api;
using AH.Shared.Api.Dtos;
using AH.Shared.Api.Swagger;
using AH.Shared.Infrastructure;
using AutoMapper;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var swagger = new SwaggerDocSetup("AgilityHealth.Tags.WebApi", PermissionDefinitions.GetPermissions());
var auth0Config = new Auth0Configuration(
    builder.Configuration[$"Auth0:Domain"],
    builder.Configuration["Auth0:Audience"],
    builder.Configuration["Auth0:ClientId"],
    builder.Configuration["Auth0:ClientSecret"]
);

builder.Services.AddApplication();
builder.Services.AddMessageSender(builder.Configuration);
builder.Services.AddControllers().AddDapr().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPersistence(builder.Configuration);

// builder.Services.AddSwaggerGen(setup =>
// {
//     setup.DocumentFilter<LowercaseDocumentFilter>();
//     setup.DocumentFilter<JsonPatchDocumentFilter>();
//     setup.EnableAnnotations();
//     setup.ExampleFilters();
//
//     // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//     // setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
// });
// builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

var mapper = new MapperConfiguration(c =>
{
    c.AddProfile(new MappingProfile());
    c.AddProfile(new ApiMappingProfileV1());
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IMasterTagCategoriesMessageSender, MasterTagCategoriesMessageSender>();


builder.Services.Build(swagger,auth0Config);
var app = builder.Build();
app.Initialize(auth0Config);

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

//app.UseRouting();
//app.UseAuthorization();
app.UseCloudEvents();
app.MapSubscribeHandler();
app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();
#if DEBUG
 Debugger.Launch();
#endif
app.Run();
