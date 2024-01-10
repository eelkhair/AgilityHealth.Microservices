using AH.Company.Application.Queries.CompanyTeamMemberTags;
using AH.Company.Application.Queries.CompanyTeamTags;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyTeamMemberTagsController
/// </summary>
public class CompanyTeamMemberTagsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyTeamMemberTagsController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company team member tags by category
    /// </summary>
    /// <param name="companyTeamMemberCategoryUId"></param>
    /// <returns></returns>
    [HttpGet("{companyTeamMemberCategoryUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyTeamMemberCategoryUId)
    {
        var query = new ListCompanyTeamMemberTagsQuery(User, Logger, companyTeamMemberCategoryUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyTeamMemberTagResponse>>(result));
    }
}