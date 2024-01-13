using AH.Company.Application.Queries.CompanyTagCategories;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyStakeholderCategoriesController
/// </summary>
public class CompanyStakeholderCategoriesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyStakeholderCategoriesController(IMapper mapper, ILogger<CompanyStakeholderCategoriesController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company stakeholder categories by company
    /// </summary>
    /// <param name="companyUId"></param>
    /// <returns></returns>
    [HttpGet("{companyUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyUId)
    {
        var query = new ListCompanyStakeholderCategoriesQuery(User, Logger, companyUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyCategoryResponse>>(result));
    }
}