using System.Diagnostics;
using AH.Company.Application.Interfaces;
using AH.Company.Application.Queries.MasterTagCategories;
using AH.Company.Application.Queries.MasterTags;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AH.Company.Api.Controllers;

/// <summary>
/// MasterTagsController
/// </summary>
public class MasterTagsController : BaseController
{
    private readonly ICompanyMicroServiceDbContext _contextAccessor;
   

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <returns></returns>
    public MasterTagsController(IMapper mapper, ILogger logger, IMediator mediator, ICompanyMicroServiceDbContext contextAccessor) : base(mapper, logger, mediator)
    {
        _contextAccessor = contextAccessor;
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
        return Ok(result);
    } 
}