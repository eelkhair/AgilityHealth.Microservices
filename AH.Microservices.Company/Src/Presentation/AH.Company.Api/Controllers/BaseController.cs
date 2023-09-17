using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// Base controller for all controllers
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly IMapper Mapper;
    protected readonly ILogger Logger;
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
