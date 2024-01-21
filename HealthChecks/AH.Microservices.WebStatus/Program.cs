var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHealthChecksUI()
    .AddInMemoryStorage();

builder.Logging.AddJsonConsole();

var app = builder.Build();

var pathBase = builder.Configuration["PATH_BASE"];
if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase(pathBase);
}

app.MapGet(string.IsNullOrEmpty(pathBase)
    ? "/"
    : pathBase, () => Results.LocalRedirect("~/healthchecks-ui"));
app.MapHealthChecksUI();

app.Run();