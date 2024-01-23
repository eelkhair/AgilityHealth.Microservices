using AH.User.Api.Controllers;
using AH.User.Application.Commands.Auth;
using AutoMapper;
using Dapr.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.User.Api.TimerTriggers;

/// <summary>
/// TimerTrigger Controller
/// </summary>

[ApiController]
public class TimerTriggerController(
    IMapper mapper,
    IMediator mediator,
    ILogger<TimerTriggerController> logger)
    : BaseController(mapper, logger, mediator)
{

    /// <summary>
    /// Refresh Auth0 Token
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("/refresh-auth-token")]
    public async Task<IActionResult> Post()
    {
        var token = await Mediator.Send(new StoreAuth0TokenCommand(User, logger));

        return Ok(token);
    }
}