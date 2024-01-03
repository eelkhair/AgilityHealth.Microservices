using AH.Company.Application.Queries.Companies;
using AH.Company.Shared.V1.Models.Companies.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompaniesController
/// </summary>
public class CompaniesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    /// <returns></returns>
    public CompaniesController(IMapper mapper, ILogger<CompaniesController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all companies
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns all companies</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there was an internal server error</response>
    /// <remarks></remarks>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListCompaniesQuery(User, Logger);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyResponse>>(result));
    }
    
}
