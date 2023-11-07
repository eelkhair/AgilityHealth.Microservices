using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners;

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

        /// <summary>
        /// Create a user object for the current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected static ClaimsPrincipal CreateUser(string userId)
        {
            var claims = new List<Claim> () { 
                new Claim (ClaimTypes.NameIdentifier, userId), 
            }; 
            var identity = new ClaimsIdentity (claims, "TestAuthType"); 
            return new ClaimsPrincipal (identity);
        }
}