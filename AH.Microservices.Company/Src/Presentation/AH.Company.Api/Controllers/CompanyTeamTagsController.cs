using AH.Company.Application.Queries.CompanyTeamTags;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyTeamTagsController
/// </summary>
public class CompanyTeamTagsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyTeamTagsController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company team tags by category
    /// </summary>
    /// <param name="companyTeamCategoryUId"></param>
    /// <returns></returns>
    [HttpGet("{companyTeamCategoryUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyTeamCategoryUId)
    {
        var query = new ListCompanyTeamTagsQuery(User, Logger, companyTeamCategoryUId);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}