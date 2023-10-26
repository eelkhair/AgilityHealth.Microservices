using System.Text.Json;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application.Commands.MasterTagCategories;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Queries.MasterTagCategories;
using AH.Metadata.Shared.V1.Models.Requests.Tags;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Shared.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Represents a MasterTagCategoriesController.
/// </summary>
public class MasterTagCategoriesController : BaseController
{
    
    private readonly IMasterTagCategoriesMessageSender _sender;

    /// <summary>
    /// Constructor for MasterTagCategoriesController.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="mediator">The mediator.</param>
    /// <param name="sender">The master tag category event sender.</param>
    /// <param name="correlationId">The correlation id.</param>
    public MasterTagCategoriesController(IMapper mapper, ILogger logger, IMediator mediator, IMasterTagCategoriesMessageSender sender, ICorrelationId correlationId) : base(mapper, logger, mediator, correlationId)
    {
        _sender = sender;
    }
    
    /// <summary>
    /// Get a list of all master tag categories
    /// </summary>
    /// <response code="200">Successfully retrieved list of master tag categories</response>
    /// <response code="404">No master tag categories exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<MasterTagCategoryResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetMasterTagCategories()
    {
        Logger.LogInformation("Getting all master tag categories");
        var query = new ListMasterTagCategoriesQuery(User, Logger);
        var masterTagCategories = await Mediator.Send(query);
        if(masterTagCategories.Count == 0) return NotFound();
        
        var model = Mapper.Map<List<MasterTagCategoryResponse>>(masterTagCategories);
        Logger.LogInformation("{Count} master tag categories found.{Data}", masterTagCategories.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Get a list of all master tag categories with tags
    /// </summary>
    /// <response code="200">Successfully retrieved list of master tag categories with tags</response>
    /// <response code="404">No master tag categories exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<MasterTagCategoryWithTagsResponse>), StatusCodes.Status200OK)]
    [HttpGet("with-tags")]
    public async Task<IActionResult> GetMasterTagCategoriesWithTags()
    {
        Logger.LogInformation("Getting all master tag categories with tags");
        var query = new ListMasterTagCategoriesWithTagsQuery(User, Logger);
        var masterTagCategories = await Mediator.Send(query);
        if(masterTagCategories.Count == 0) return NotFound();
        
        var model = Mapper.Map<List<MasterTagCategoryWithTagsResponse>>(masterTagCategories);
        Logger.LogInformation("{Count} master tag categories with tags found.{Data}", masterTagCategories.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Get a master tag category by uid
    /// </summary>
    /// <param name="uid">The uid of the master tag category</param>
    /// <response code="200">Successfully retrieved master tag category</response>
    /// <response code="404">Master tag category does not exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [ProducesResponseType(typeof(MasterTagCategoryWithTagsResponse), StatusCodes.Status200OK)]
    [HttpGet("{uid:guid}")]
    public async Task<IActionResult> GetMasterTagCategory(Guid uid)
    {
        if(uid == Guid.Empty) throw new ArgumentNullException(nameof(uid));
        
        Logger.LogInformation("Getting master tag category with uid {Uid}", uid);
        var query = new GetMasterTagCategoryQuery(User, Logger, uid);
        var masterTagCategory = await Mediator.Send(query);
        if(masterTagCategory == null) return NotFound();
        
        var model = Mapper.Map<MasterTagCategoryWithTagsResponse>(masterTagCategory);
        Logger.LogInformation("Master tag category with uid {Uid} found.{Data}", uid, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Create a new master tag category
    /// </summary>
    /// <param name="request">The request</param>
    /// <response code="201">Successfully created master tag category</response>
    /// <response code="400">Invalid request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [ProducesResponseType(typeof(MasterTagCategoryResponse), StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> CreateMasterTagCategory([FromQuery] MasterTagCategoryRequest request)
    {
        if(request == null) throw new ArgumentNullException(nameof(request));
        
        Logger.LogInformation("CorrelationId: {CorrelationId}Creating master tag category", CorrelationId.Get());
        var dto = Mapper.Map<MasterTagCategoryDto>(request);
        
        var command = new CreateMasterTagCategoryCommand(User, Logger, dto);
        var masterTagCategory = await Mediator.Send(command);
        
        var model = Mapper.Map<MasterTagCategoryResponse>(masterTagCategory);
        Logger.LogInformation("Master tag category created.{Data}", JsonSerializer.Serialize(model));
        
        await _sender.SendCreateMasterTagCategoryMessageAsync(User, masterTagCategory);
        
        return CreatedAtAction(nameof(GetMasterTagCategory), new { uid = model.UId }, model);
    }

    /// <summary>
    /// Update a master tag category
    /// </summary>
    /// <param name="uid">The uid of the master tag category</param>
    /// <param name="request">The request</param>
    /// <response code="200">Successfully updated master tag category</response>
    /// <response code="400">Invalid request</response>
    /// <response code="404">Master tag category does not exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [ProducesResponseType(typeof(MasterTagCategoryResponse), StatusCodes.Status200OK)]
    [HttpPut("{uid:guid}")]
    public async Task<IActionResult> UpdateMasterTagCategory(Guid uid,  [FromQuery] MasterTagCategoryRequest request)
    {
        if(uid == Guid.Empty) throw new ArgumentNullException(nameof(uid));
        if(request == null) throw new ArgumentNullException(nameof(request));
        
        Logger.LogInformation("Updating master tag category with uid {Uid}", uid);
        var dto = Mapper.Map<MasterTagCategoryDto>(request);
        dto.UId = uid;
        
        var command = new UpdateMasterTagCategoryCommand(User, Logger, dto);
        var masterTagCategory = await Mediator.Send(command);
        if(masterTagCategory == null) return NotFound();
        
        var model = Mapper.Map<MasterTagCategoryResponse>(masterTagCategory);
        Logger.LogInformation("Master tag category with uid {Uid} updated.{Data}", uid, JsonSerializer.Serialize(model));
        
        await _sender.SendUpdateMasterTagCategoryMessageAsync(User, masterTagCategory);      
        
        return Ok(model);
    }
    
    /// <summary>
    /// Delete a master tag category
    /// </summary>
    /// <param name="uid">The uid of the master tag category</param>
    /// <response code="204">Successfully deleted master tag category</response>
    /// <response code="400">Invalid request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{uid:guid}")]
    public async Task<IActionResult> DeleteMasterTagCategory(Guid uid)
    {
        if(uid == Guid.Empty) throw new ArgumentNullException(nameof(uid));
        
        Logger.LogInformation("Deleting master tag category with uid {Uid}", uid);
        var command = new DeleteMasterTagCategoryCommand(User, Logger, uid);
        var dto = await Mediator.Send(command);
        
        Logger.LogInformation("Master tag category with uid {Uid} deleted", uid);
        
        await _sender.SendDeleteMasterTagCategoryMessageAsync(User, dto);  
        
        return NoContent();
    }

}