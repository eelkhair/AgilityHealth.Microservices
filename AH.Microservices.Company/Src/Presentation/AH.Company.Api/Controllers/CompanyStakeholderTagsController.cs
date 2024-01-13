using AH.Company.Application.Queries.CompanyTags;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyStakeholderTagsController
/// </summary>
public class CompanyStakeholderTagsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyStakeholderTagsController(IMapper mapper, ILogger<CompanyStakeholderTagsController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company stakeholder tags by category
    /// </summary>
    /// <param name="companyStakeholderCategoryUId"></param>
    /// <returns></returns>
    [HttpGet("{companyStakeholderCategoryUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyStakeholderCategoryUId)
    {
        var query = new ListCompanyStakeholdersQuery(User, Logger, companyStakeholderCategoryUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyTagResponse>>(result));
    }
}