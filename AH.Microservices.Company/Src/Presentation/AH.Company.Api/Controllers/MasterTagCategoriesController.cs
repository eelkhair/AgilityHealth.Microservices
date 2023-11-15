using System.Diagnostics;
using AH.Company.Application.Interfaces;
using AH.Company.Application.Queries.MasterTagCategories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AH.Company.Api.Controllers;

/// <summary>
/// MasterTagCategoriesController
/// </summary>
public class MasterTagCategoriesController : BaseController
{
    private readonly ICompanyMicroServiceDbContext _contextAccessor;
   

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <returns></returns>
    public MasterTagCategoriesController(IMapper mapper, ILogger logger, IMediator mediator, ICompanyMicroServiceDbContext contextAccessor) : base(mapper, logger, mediator)
    {
        _contextAccessor = contextAccessor;
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
        return Ok(result);
    } 
    [HttpGet("GetConnectionInfo")]
    public async Task<IActionResult> GetConnectionInfo()
    {
        return Ok(_contextAccessor.GetConnectionString());
    }
}