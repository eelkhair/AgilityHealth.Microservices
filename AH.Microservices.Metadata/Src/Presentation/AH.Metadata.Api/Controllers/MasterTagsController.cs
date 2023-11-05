using System.Text.Json;
using AH.Metadata.Application.Commands.MasterTags;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Queries.MasterTags;
using AH.Metadata.Shared.V1.Models.Requests.Tags;
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
    
    /// <summary>
    /// Get a list of all master tags by category
    /// </summary>
    /// <param name="masterTagCategoryUId">The master tag category unique identifier.</param>
    /// <response code="200">Successfully retrieved list of master tags</response>
    /// <response code="404">No master tags exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<MasterTagResponse>), StatusCodes.Status200OK)]
    [HttpGet("category/{masterTagCategoryUId:guid}")]
    public async Task<IActionResult> GetMasterTagsByCategory(Guid masterTagCategoryUId)
    {
        Logger.LogInformation("Getting all master tags by category with UId {UId}", masterTagCategoryUId);
        var query = new ListMasterTagsByCategoryQuery(User, Logger, masterTagCategoryUId);
        var masterTags = await Mediator.Send(query);
        if(masterTags.Count == 0) return NotFound();
        
        var model = Mapper.Map<List<MasterTagResponse>>(masterTags);
        Logger.LogInformation("{Count} master tags found.{Data}", masterTags.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Get a master tag by its unique identifier
    /// </summary>
    /// <param name="masterTagUId">The master tag unique identifier.</param>
    /// <response code="200">Successfully retrieved master tag</response>
    /// <response code="404">Master tag does not exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(MasterTagWithCategoryAndParentTagResponse), StatusCodes.Status200OK)]
    [HttpGet("{masterTagUId:guid}")]
    public async Task<IActionResult> GetMasterTag(Guid masterTagUId)
    {
        Logger.LogInformation("Getting master tag with UId {UId}", masterTagUId);
        var query = new GetMasterTagQuery(User, Logger, masterTagUId);
        var masterTag = await Mediator.Send(query);
        if(masterTag == null) return NotFound();
        
        var model = Mapper.Map<MasterTagResponse>(masterTag);
        Logger.LogInformation("Master tag with UId {UId} found.{Data}", masterTagUId, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Create a master tag
    /// </summary>
    /// <param name="request">The master tag request.</param>
    /// <response code="201">Successfully created master tag</response>
    /// <response code="400">Invalid master tag request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(MasterTagWithCategoryAndParentTagResponse), StatusCodes.Status201Created)]
    [HttpPost]
    public  async Task<IActionResult> CreateMasterTag([FromQuery] MasterTagRequest request)
    {
        var dto = Mapper.Map<MasterTagDto>(request);
        Logger.LogInformation("Creating master tag with name {Name}", request.Name);
        var command = new CreateMasterTagCommand(User, Logger, dto);
        var masterTag = await Mediator.Send(command);
        
        var model = Mapper.Map<MasterTagWithCategoryAndParentTagResponse>(masterTag);
        Logger.LogInformation("Master tag with name {Name} created.{Data}", request.Name, JsonSerializer.Serialize(model));
        
        return CreatedAtAction(nameof(GetMasterTag), new {masterTagUId = masterTag.UId}, model);
    }
    
    /// <summary>
    /// Update a master tag
    /// </summary>
    /// <param name="masterTagUId">The master tag unique identifier.</param>
    /// <param name="request">The master tag request.</param>
    /// <response code="200">Successfully updated master tag</response>
    /// <response code="400">Invalid master tag request</response>
    /// <response code="404">Master tag does not exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(MasterTagWithCategoryAndParentTagResponse), StatusCodes.Status200OK)]
    [HttpPut("{masterTagUId:guid}")]
    public async Task<IActionResult> UpdateMasterTag(Guid masterTagUId, [FromQuery] MasterTagRequest request)
    {
        var dto = Mapper.Map<MasterTagDto>(request);
        dto.UId = masterTagUId;
        Logger.LogInformation("Updating master tag with UId {UId}", masterTagUId);
        var command = new UpdateMasterTagCommand(User, Logger, dto);
        var masterTag = await Mediator.Send(command);
        if(masterTag == null) return NotFound();
        
        var model = Mapper.Map<MasterTagWithCategoryAndParentTagResponse>(masterTag);
        Logger.LogInformation("Master tag with UId {UId} updated.{Data}", masterTagUId, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Delete a master tag
    /// </summary>
    /// <param name="masterTagUId">The master tag unique identifier.</param>
    /// <response code="204">Successfully deleted master tag</response>
    /// <response code="404">Master tag does not exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{masterTagUId:guid}")]
    public async Task<IActionResult> DeleteMasterTag(Guid masterTagUId)
    {
        Logger.LogInformation("Deleting master tag with UId {UId}", masterTagUId);
        var command = new DeleteMasterTagCommand(User, Logger, masterTagUId);
        var masterTag = await Mediator.Send(command);
        if(masterTag == null) return NotFound();
        
        Logger.LogInformation("Master tag with UId {UId} deleted. ", masterTagUId);
        
        return NoContent();
    }
}