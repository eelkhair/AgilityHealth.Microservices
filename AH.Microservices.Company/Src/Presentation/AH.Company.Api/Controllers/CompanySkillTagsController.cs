using AH.Company.Application.Queries.CompanyTags;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanySkillTagsController
/// </summary>
public class CompanySkillTagsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanySkillTagsController(IMapper mapper, ILogger<CompanySkillTagsController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company skill tags by category
    /// </summary>
    /// <param name="companySkillCategoryUId"></param>
    /// <returns></returns>
    [HttpGet("{companySkillCategoryUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companySkillCategoryUId)
    {
        var query = new ListCompanySkillsQuery(User, Logger, companySkillCategoryUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyTagResponse>>(result));
    }
}