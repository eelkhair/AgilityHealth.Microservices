using AH.Web.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using AH.Web.Services;
using AH.Web.Services.Interfaces;
using Dapr.Client;
using AH.Web.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<TokenProvider>();
builder.Services.AddSingleton<IMasterTagCategoryService, MasterTagCategoryService>(
    p=> new MasterTagCategoryService(DaprClient.CreateInvokeHttpClient("ah-metadata"), p.GetRequiredService<TokenProvider>()));


builder.Services.AddTelerikBlazor();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
  .AddCookie()
  .AddOpenIdConnect("Auth0", options => {
      options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
      options.ClientId = builder.Configuration["Auth0:ClientId"];
      options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
      options.SaveTokens = true;
      options.ResponseType = OpenIdConnectResponseType.Code;
      options.CallbackPath = new PathString("/callback");
      options.ProtocolValidator.RequireNonce = false;
      options.TokenValidationParameters = new TokenValidationParameters
      {
          NameClaimType = "name"
      };
      options.Events = new OpenIdConnectEvents
      {
          OnRedirectToIdentityProviderForSignOut = (context) =>
          {
              var logoutUri = $"https://{builder.Configuration["Auth0:Domain"]}/v2/logout?client_id={builder.Configuration["Auth0:ClientId"]}";

              var postLogoutUri = context.Properties.RedirectUri;
              if (!string.IsNullOrEmpty(postLogoutUri))
              {
                  if (postLogoutUri.StartsWith('/'))
                  {
                      // transform to absolute
                      var request = context.Request;
                      postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                  }
                  logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
              }

              context.Response.Redirect(logoutUri);
              context.HandleResponse();

              return Task.CompletedTask;
          },
          OnRedirectToIdentityProvider = context =>
          {
              context.ProtocolMessage.SetParameter("audience", builder.Configuration["Auth0:Audience"]);
              return Task.FromResult(0);
          }

          
      };
  });
IdentityModelEventSource.ShowPII = true;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRouting();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.UseAuthentication();
app.UseAuthorization();


app.MapGet("account/login", async (string returnUrl, HttpContext context) =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
         .WithRedirectUri(returnUrl)
         .Build();

    await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("account/logout", async context =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
         .WithRedirectUri("/")
         .Build();

    await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

#if DEBUG
 //   Debugger.Launch();
#endif

app.Run();
