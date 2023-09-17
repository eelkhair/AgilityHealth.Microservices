using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

public class TestController : BaseController
{
    public TestController(IMapper mapper, ILogger<TestController> logger , IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Logger.LogInformation("TestController.Get() called");
        return Ok();
    }
}