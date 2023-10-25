using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners;

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
        protected IMapper Mapper;
        /// <summary>
        /// Logger
        /// </summary>
        protected ILogger Logger;
        /// <summary>
        /// Mediator
        /// </summary>
        protected IMediator Mediator;
        /// <summary>
        /// Context
        /// </summary>
        protected ICompanyMicroServiceDbContext Context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        protected BaseMessageListener(IMapper mapper, ILogger logger, IMediator mediator, ICompanyMicroServiceDbContext context)
        {
            Mapper = mapper;
            Logger = logger;
            Mediator = mediator;
            Context = context;
        }
}