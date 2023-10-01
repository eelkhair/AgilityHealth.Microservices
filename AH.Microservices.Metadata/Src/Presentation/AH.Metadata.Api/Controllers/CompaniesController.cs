using System.Text.Json;
using AH.Metadata.Application.Queries.Companies;
using AH.Metadata.Shared.V1.Models.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Companies Controller
/// </summary>
public class CompaniesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompaniesController(IMapper mapper, ILogger<CompaniesController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get a list of all companies
    /// </summary>
    /// <response code="200">Successfully retrieved list of companies</response>
    /// <response code="404">No companies exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    
    [ProducesResponseType(typeof(List<CompanyResponse>), StatusCodes.Status200OK)]
    [HttpGet]   
    public async Task<IActionResult> GetCompanies()
    {
        Logger.LogInformation("Getting all companies");
        var query = new ListCompaniesQuery(User, Logger);
        var companies = await Mediator.Send(query);
        
        var model = Mapper.Map<List<CompanyResponse>>(companies);
        Logger.LogInformation("{Count} companies found.{Data}", companies.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
}