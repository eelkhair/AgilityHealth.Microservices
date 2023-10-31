using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.User.Api.Controllers;

/// <summary>
/// Test Controller
/// </summary>
public class TestController : BaseController
{
    public TestController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Hello World");
    }
}