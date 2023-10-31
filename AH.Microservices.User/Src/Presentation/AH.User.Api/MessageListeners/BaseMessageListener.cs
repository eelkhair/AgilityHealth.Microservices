using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.User.Api.MessageListeners;

/// <summary>
/// Base class for message listeners
/// </summary>
[ApiController]
[Route("api/[controller]/pubsub")]
[ApiExplorerSettings(IgnoreApi = true)]
public abstract class BaseMessageListener : ControllerBase
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