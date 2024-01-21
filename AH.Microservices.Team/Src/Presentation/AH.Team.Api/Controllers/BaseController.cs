using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Team.Api.Controllers;

/// <summary>
/// Base controller for all controllers
/// </summary>
[ApiController]
[Route("api/[controller]")]

public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Mapper
    /// </summary>
    protected readonly IMapper Mapper;
    /// <summary>
    /// Logger
    /// </summary>
    protected readonly ILogger Logger;
    /// <summary>
    /// Mediator
    /// </summary>
    protected readonly IMediator Mediator;

    /// <summary>
    /// Constructor for base controller
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    protected BaseController(IMapper mapper, ILogger logger, IMediator mediator)
    {
        Mapper = mapper;
        Logger = logger;
        Mediator = mediator;
    }
}
