using AH.User.Api.Controllers;
using AH.User.Application.Commands.Auth;
using AutoMapper;
using Dapr.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.User.Api.TimerTriggers;

/// <summary>
/// Test Controller
/// </summary>

[ApiController]
public class TimerTriggerController : BaseController
{
    private readonly ILogger<TimerTriggerController> _logger;
    private readonly DaprClient _daprClient;

    public TimerTriggerController(IMapper mapper, IMediator mediator, ILogger<TimerTriggerController> logger, DaprClient daprClient) : base(mapper,logger, mediator)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpPost]
    [Route("/refresh-auth-token")]
    public async Task<IActionResult> Post()
    {
        await Mediator.Send(new StoreAuth0TokenCommand(User, _logger));

        return Ok();
    }
}