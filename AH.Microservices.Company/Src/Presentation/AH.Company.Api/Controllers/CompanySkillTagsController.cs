using AH.Company.Application.Commands.CompanyTags.Skill;
using AH.Company.Application.Dtos;
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
    
    /// <summary>
    /// Create a new company skill tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanySkillTagDto>(tag);
        var command = new CreateCompanySkillTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Update a company skill tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanySkillTagDto>(tag);
        var command = new UpdateCompanySkillTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Delete a company skill tag
    /// </summary>
    /// <param name="tagUId"></param>
    /// <returns></returns>
    [HttpDelete("{tagUId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid tagUId)
    {
        var command = new DeleteCompanySkillTagCommand(User, Logger, tagUId);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}