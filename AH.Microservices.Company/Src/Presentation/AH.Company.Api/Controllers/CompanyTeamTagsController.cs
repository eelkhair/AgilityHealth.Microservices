using AH.Company.Application.Commands.CompanyTags.Team;
using AH.Company.Application.Dtos;
using AH.Company.Application.Queries.CompanyTags;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

/// <summary>
/// CompanyTeamTagsController
/// </summary>
public class CompanyTeamTagsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompanyTeamTagsController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    /// <summary>
    /// Get all company team tags by category
    /// </summary>
    /// <param name="companyTeamCategoryUId"></param>
    /// <returns></returns>
    [HttpGet("{companyTeamCategoryUId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid companyTeamCategoryUId)
    {
        var query = new ListCompanyTeamTagsQuery(User, Logger, companyTeamCategoryUId);
        var result = await Mediator.Send(query);
        return Ok(Mapper.Map<List<CompanyTagResponse>>(result));
    }
    
    /// <summary>
    /// Create new company team tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanyTeamTagDto>(tag);
        var command = new CreateCompanyTeamTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Update company team tag
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CompanyTagResponse tag)
    {
        var dto = Mapper.Map<CompanyTeamTagDto>(tag);
        var command = new UpdateCompanyTeamTagCommand(User, Logger, dto);
        var result = await Mediator.Send(command);
        return Ok(Mapper.Map<CompanyTagResponse>(result));
    }
    
    /// <summary>
    /// Delete company team tag
    /// </summary>
    /// <param name="tagUId"></param>
    /// <returns></returns>
    [HttpDelete("{tagUId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid tagUId)
    {
        var command = new DeleteCompanyTeamTagCommand(User, Logger, tagUId);
        await Mediator.Send(command);
        return Ok();
    }
}