using AH.Company.Application.Queries.MasterTagCategories;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AH.Company.Api.Controllers;

/// <summary>
/// MasterTagCategoriesController
/// </summary>
public class MasterTagCategoriesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <returns></returns>
    public MasterTagCategoriesController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {

    }
    
    /// <summary>
    /// Get all master tag categories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListMasterTagCategoriesQuery(User, Logger);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyMasterTagCategoryResponse>>(result));
    } 
}