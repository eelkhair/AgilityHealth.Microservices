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
    protected readonly IMapper Mapper;
    protected readonly ILogger Logger;
    protected readonly IMediator Mediator;
    protected readonly ICorrelationId CorrelationId;

    /// <summary>
    /// Constructor for base controller
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    protected BaseController(IMapper mapper, ILogger logger, IMediator mediator, ICorrelationId correlationId)
    {
        Mapper = mapper;
        Logger = logger;
        Mediator = mediator;
        CorrelationId = correlationId;
    }
}
