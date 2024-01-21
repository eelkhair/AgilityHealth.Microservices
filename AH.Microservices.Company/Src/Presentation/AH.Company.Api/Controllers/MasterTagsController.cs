using AH.Company.Application.Queries.MasterTags;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AH.Company.Api.Controllers;

/// <summary>
/// MasterTagsController
/// </summary>
public class MasterTagsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <returns></returns>
    public MasterTagsController(IMapper mapper, ILogger<MasterTagCategoriesController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
  
    }
    
    /// <summary>
    /// Get all master tags
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListMasterTagsQuery(User, Logger);
        var result = await Mediator.Send(query);
        
        return Ok(Mapper.Map<List<CompanyMasterTagResponse>>(result));
    } 
}