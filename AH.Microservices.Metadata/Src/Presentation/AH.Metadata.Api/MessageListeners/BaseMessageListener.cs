using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.MessageListeners;

/// <summary>
/// Base class for message listeners
/// </summary>
[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public abstract class BaseMessageListener : ControllerBase
{
        /// <summary>
        /// Mapper
        /// </summary>
        // ReSharper disable once NotAccessedField.Global
        protected IMapper Mapper;
        /// <summary>
        /// Logger
        /// </summary>
        // ReSharper disable once NotAccessedField.Global
        protected ILogger Logger;
        /// <summary>
        /// Mediator
        /// </summary>
        // ReSharper disable once NotAccessedField.Global
        protected IMediator Mediator;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        protected BaseMessageListener(IMapper mapper, ILogger logger, IMediator mediator)
        {
            Mapper = mapper;
            Logger = logger;
            Mediator = mediator;
        }
}