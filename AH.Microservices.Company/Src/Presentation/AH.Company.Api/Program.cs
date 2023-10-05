using System.Diagnostics;
using System.Reflection;
using AH.Company.Api.Configuration.Filters;
using AH.Company.Api.Configuration.Middleware;
using AH.Company.Api.Models;
using AH.Company.Application;
using AH.Company.Application.Dtos;
using AH.Company.Persistence;
using AH.Shared.Infrastructure;
using AutoMapper;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMessageSender(builder.Configuration);

builder.Services.AddApplication();
builder.Services.AddControllers().AddDapr();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddSwaggerGen(setup =>
{
    setup.DocumentFilter<LowercaseDocumentFilter>();
    setup.DocumentFilter<JsonPatchDocumentFilter>();
    setup.EnableAnnotations();
    setup.ExampleFilters();
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
var mapper = new MapperConfiguration(c =>
{
    c.AddProfile(new MappingProfile());
    c.AddProfile(new ApiMappingProfileV1());
}).CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddActors(options =>
{
  // Example :  options.Actors.RegisterActor<MetadataActor>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseCloudEvents();
app.MapSubscribeHandler();
app.MapControllers();
app.MapActorsHandlers();
app.UseMiddleware<ExceptionHandlerMiddleware>();
#if DEBUG
Debugger.Launch();
#endif

app.Run();
