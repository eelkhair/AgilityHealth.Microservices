using System.Diagnostics;
using AH.Company.Application;
using AH.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessageSender(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers().AddDapr();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
#if DEBUG
Debugger.Launch();
#endif
app.Run();