using AH.Company.Application.Commands.CompanyTagCategories.Stakeholder;
using AH.Company.Application.Dtos;
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
    
    /// <summary>
    /// Create company stakeholder category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanyStakeholderCategoryDto>(category);
        var command = new CreateCompanyStakeholderCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Update company stakeholder category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanyStakeholderCategoryDto>(category);
        var command = new UpdateCompanyStakeholderCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Delete company stakeholder category
    /// </summary>
    /// <param name="categoryUId"></param>
    /// <returns></returns>
    [HttpDelete("{categoryUId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid categoryUId)
    {
        var command = new DeleteCompanyStakeholderCategoryCommand(User, Logger, categoryUId);
        await Mediator.Send(command);
        return Ok();
    }
}