using AH.Company.Application.Queries.CompanyTeamCategories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyTeamCategoriesController
/// </summary>
public class CompanyTeamCategoriesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyTeamCategoriesController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company team categories by company
    /// </summary>
    /// <param name="companyUId"></param>
    /// <returns></returns>
    [HttpGet("{companyUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyUId)
    {
        var query = new ListCompanyTeamCategoriesQuery(User, Logger, companyUId);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}