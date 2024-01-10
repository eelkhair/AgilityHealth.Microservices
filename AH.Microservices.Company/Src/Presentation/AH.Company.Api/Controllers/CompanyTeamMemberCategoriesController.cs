using AH.Company.Application.Queries.CompanyTeamMemberCategories;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyTeamCategoriesController
/// </summary>
public class CompanyTeamMemberCategoriesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyTeamMemberCategoriesController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company team member categories by company
    /// </summary>
    /// <param name="companyUId"></param>
    /// <returns></returns>
    [HttpGet("{companyUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyUId)
    {
        var query = new ListCompanyTeamMemberCategoriesQuery(User, Logger, companyUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyTeamMemberCategoryResponse>>(result));
    }
}