using AH.Company.Application.Commands.CompanyTagCategories.Skill;
using AH.Company.Application.Dtos;
using AH.Company.Application.Queries.CompanyTagCategories;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanySkillCategoriesController
/// </summary>
public class CompanySkillCategoriesController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanySkillCategoriesController(IMapper mapper, ILogger<CompanySkillCategoriesController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company skill categories by company
    /// </summary>
    /// <param name="companyUId"></param>
    /// <returns></returns>
    [HttpGet("{companyUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyUId)
    {
        var query = new ListCompanySkillCategoriesQuery(User, Logger, companyUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyCategoryResponse>>(result));
    }
    
    /// <summary>
    /// Create company skill category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanySkillCategoryDto>(category);
        var command = new CreateCompanySkillCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Update company skill category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanySkillCategoryDto>(category);
        var command = new UpdateCompanySkillCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Delete company skill category
    /// </summary>
    /// <param name="categoryUId"></param>
    /// <returns></returns>
    [HttpDelete("{categoryUId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid categoryUId)
    {
        var command = new DeleteCompanySkillCategoryCommand(User, Logger, categoryUId);
        await Mediator.Send(command);
        return Ok();
    }
}