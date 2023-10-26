using System.Text.Json;
using AH.Metadata.Application.Queries.MasterTags;
using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AH.Shared.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Represents a MasterTagsController.
/// </summary>
public class MasterTagsController : BaseController
{
    /// <summary>
    /// Constructor for MasterTagsController.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="mediator">The mediator.</param>
    /// <param name="correlationId">The correlationId.</param>
    public MasterTagsController(IMapper mapper, ILogger logger, IMediator mediator, ICorrelationId correlationId) : base(mapper, logger, mediator, correlationId)
    {
    }
    
    /// <summary>
    /// Get a list of all master tags
    /// </summary>
    /// <response code="200">Successfully retrieved list of master tags</response>
    /// <response code="404">No master tags exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<MasterTagResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetMasterTags()
    {
        Logger.LogInformation("Getting all master tags");
        var query = new ListMasterTagsQuery(User, Logger);
        var masterTags = await Mediator.Send(query);
        if(masterTags.Count == 0) return NotFound();
        
        var model = Mapper.Map<List<MasterTagResponse>>(masterTags);
        Logger.LogInformation("{Count} master tags found.{Data}", masterTags.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
}