
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AH.Company.Api.TimerTriggers;

/// <summary>
/// TimerTrigger Controller
/// </summary>

[ApiController]

public class TimerTriggerController(
    IMapper mapper,
    IMediator mediator,
    ILogger<TimerTriggerController> logger) :ControllerBase
{

    /// <summary>
    /// Cache Company and its related data
    /// </summary>
    /// <returns></returns>
    [HttpPost("/cache-company")]

    public async Task<IActionResult> Post()

    {
        return Ok("Cache Company ");
    }   
}