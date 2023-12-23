using System.Net;
using Microsoft.AspNetCore.Mvc;
using AH.Web.Shared;
using Dapr.Client;
using Microsoft.AspNetCore.Authorization;

namespace AH.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task< ActionResult<IEnumerable<WeatherForecast>>> Get()
    {
        var client = DaprClient.CreateInvokeHttpClient("ah-metadata-api");
        client.DefaultRequestHeaders.Add("Authorization", this.Request.Headers["Authorization"].FirstOrDefault());
        var response = await client.GetAsync("v1/domains");
        if (response.StatusCode.Equals(HttpStatusCode.InternalServerError))
        {
            return NotFound("Error Retrieving Domains");
        }
        var results = await response.Content.ReadFromJsonAsync<List<object>>();
        this.Response.Headers.Add("Trace-Id", response.Headers.Where(x=>x.Key == "Trace-Id").Select(x=>x.Value).First().FirstOrDefault());
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Domains = results
            })
            .ToArray();
    }
}