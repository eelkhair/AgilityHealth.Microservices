using AH.Company.Application.Commands.CompanyTagCategories;
using AH.Company.Application.Commands.CompanyTagCategories.Team;
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
        return Ok(Mapper.Map<List<CompanyCategoryResponse>>(result));
    }
    
    /// <summary>
    /// Create company team category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanyTeamCategoryDto>(category);
        var command = new CreateCompanyTeamCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Update company team category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var dto = Mapper.Map<CompanyTeamCategoryDto>(category);
        var command = new UpdateCompanyTeamCategoryCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyCategoryResponse>(result));
    }
    
    /// <summary>
    /// Delete company team category
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    [HttpDelete("{uid:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid uid)
    {
        var command = new DeleteCompanyTeamCategoryCommand(User, Logger, uid);
        await Mediator.Send(command);
        return Ok();
    }
}