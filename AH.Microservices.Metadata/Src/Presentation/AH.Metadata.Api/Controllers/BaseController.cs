using AH.Shared.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Base controller for all controllers
/// </summary>
[ApiController]
[Route("/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Mapper for mapping objects
    /// </summary>
    protected readonly IMapper Mapper;
    /// <summary>
    /// Logger for logging
    /// </summary>
    protected readonly ILogger Logger;
    /// <summary>
    /// Mediator for sending commands and queries
    /// </summary>
    protected readonly IMediator Mediator;
    /// <summary>
    /// CorrelationId for tracking requests across services
    /// </summary>
    protected readonly ICorrelationId CorrelationId;

    /// <summary>
    /// Constructor for base controller
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <param name="correlationId"></param>
    protected BaseController(IMapper mapper, ILogger logger, IMediator mediator, ICorrelationId correlationId)
    {
        Mapper = mapper;
        Logger = logger;
        Mediator = mediator;
        CorrelationId = correlationId;
    }
}
