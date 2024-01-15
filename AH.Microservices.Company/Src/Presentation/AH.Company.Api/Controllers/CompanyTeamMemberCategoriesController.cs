using AH.Company.Application.Commands.CompanyTagCategories.TeamMember;
using AH.Company.Application.Dtos;
using AH.Company.Application.Queries.CompanyTagCategories;
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
        return Ok(Mapper.Map<List<CompanyCategoryResponse>>(result));
    }
    
    /// <summary>
    /// Create company team member category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanyTeamMemberCategoryDto>(category);
        var command = new CreateCompanyTeamMemberCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Update company team member category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanyTeamMemberCategoryDto>(category);
        var command = new UpdateCompanyTeamMemberCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Delete company team member category
    /// </summary>
    /// <param name="categoryUId"></param>
    /// <returns></returns>
    [HttpDelete("{categoryUId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid categoryUId)
    {
        var command = new DeleteCompanyTeamMemberCategoryCommand(User, Logger, categoryUId);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}