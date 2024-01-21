using AH.Company.Application.Commands.CompanyTags.TeamMember;
using AH.Company.Application.Dtos;
using AH.Company.Application.Queries.CompanyTags;
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
    public CompanyTeamMemberTagsController(IMapper mapper, ILogger<CompanyTeamMemberTagsController> logger, IMediator mediator) : base(mapper, logger, mediator)
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
        return Ok(Mapper.Map<List<CompanyTagResponse>>(result));
    }
    
    /// <summary>
    /// Create new company team member tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanyTeamMemberTagDto>(tag);
        var command = new CreateCompanyTeamMemberTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Update company team member tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanyTeamMemberTagDto>(tag);
        var command = new UpdateCompanyTeamMemberTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Delete company team member tag
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    [HttpDelete("{uid:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid uid)
    {
        var command = new DeleteCompanyTeamMemberTagCommand(User, Logger, uid);
        await Mediator.Send(command);
        return NoContent();
    }
}