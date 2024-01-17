using AH.Company.Application.Commands.CompanyTags.Stakeholder;
using AH.Company.Application.Dtos;
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
    
    /// <summary>
    /// Create a new company stakeholder tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanyStakeholderTagDto>(tag);
        var command = new CreateCompanyStakeholderTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Update a company stakeholder tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanyStakeholderTagDto>(tag);
        var command = new UpdateCompanyStakeholderTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Delete a company stakeholder tag
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    [HttpDelete("{uid:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid uid)
    {
        var command = new DeleteCompanyStakeholderTagCommand(User, Logger, uid);
        await Mediator.Send(command);
        return NoContent();
    }
}