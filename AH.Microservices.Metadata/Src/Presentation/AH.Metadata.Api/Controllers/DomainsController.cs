using System.Text.Json;
using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Queries.Domains;
using AH.Metadata.Shared.V1.Models.Requests.Domains;
using AH.Metadata.Shared.V1.Models.Responses.Domains;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Domains Controller
/// </summary>
[Authorize]
public class DomainsController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public DomainsController(IMapper mapper, ILogger<DomainsController> logger, IMediator mediator) : base(mapper, logger, mediator)
    {

    }

    /// <summary>
    /// Get a list of all domains
    /// </summary>
    /// <response code="200">Successfully retrieved list of domains</response>
    /// <response code="404">No domains exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<DomainResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetDomains()
    {
        Logger.LogInformation("Getting all domains");
        var query = new ListDomainsQuery(User, Logger);
        var domains = await Mediator.Send(query);
        if(domains.Count == 0) return NotFound();
        
        var model = Mapper.Map<List<DomainResponse>>(domains);
        Logger.LogInformation("{Count} domains found.{Data}", domains.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Get a domain by uid
    /// </summary>
    /// <param name="uid">The uid of the domain to retrieve</param>
    /// <response code="200">Successfully retrieved domain</response>
    /// <response code="404">Domain not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [HttpGet("{uid:guid}")]
    [ProducesResponseType(typeof(DomainWithCompaniesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDomain(Guid uid)
    {
        Logger.LogInformation("Getting domain {Uid}", uid);
        var query = new GetDomainQuery(User, Logger, uid);
        var domain = await Mediator.Send(query);
        if (domain == null) return NotFound();
        
        var model = Mapper.Map<DomainWithCompaniesResponse>(domain);
        Logger.LogInformation("Domain found {Data}", JsonSerializer.Serialize(model));
        
        return Ok(model);
    }

    /// <summary>
    /// Create a new domain
    /// </summary>
    /// <param name="model">The domain to create</param>
    /// <response code="201">Successfully created domain</response>
    /// <response code="400">Invalid request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(DomainResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDomain([FromQuery] DomainRequest model)
    {
        var dto = Mapper.Map<DomainDto>(model);
        Logger.LogInformation("Creating domain {Data}", JsonSerializer.Serialize(model));
        
        var command = new CreateDomainCommand(User, Logger, dto);
        var domain = await Mediator.Send(command);
        
        var domainModel = Mapper.Map<DomainResponse>(domain);
        Logger.LogInformation("Domain created {Data}", JsonSerializer.Serialize(domainModel));
        
        return CreatedAtAction(nameof(GetDomain), new { uid = domain.UId }, domainModel);
    }

    /// <summary>
    /// Update a domain
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="model">The domain to update</param>
    /// <response code="201">Successfully updated domain</response>
    /// <response code="400">Invalid request</response>
    /// <response code="404">Domain not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(DomainResponse), StatusCodes.Status200OK)] 
    [HttpPut("{uid:guid}")]
    public async Task<IActionResult> UpdateDomain(Guid uid, [FromQuery] DomainRequest model)
    {
        Logger.LogInformation("Updating domain {Uid} {Data}", uid, JsonSerializer.Serialize(model));
        var dto = Mapper.Map<DomainDto>(model);
        dto.UId = uid;
        
        var command = new UpdateDomainCommand(User, Logger, dto);
        var domain = await Mediator.Send(command);
        
        var domainModel = Mapper.Map<DomainResponse>(domain);
        Logger.LogInformation("Domain updated {Data}", JsonSerializer.Serialize(domainModel));
        
        return Ok(domainModel);
    }

    /// <summary>
    /// Delete a domain
    /// </summary>
    /// <param name="uid">The uid of the domain to delete</param>
    /// <response code="204">Successfully deleted domain</response>
    /// <response code="400">Invalid request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [HttpDelete("{uid:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDomain(Guid uid)
    {
        Logger.LogInformation("Deleting domain {Uid}", uid);
        var command = new DeleteDomainCommand(User, Logger, uid);
        await Mediator.Send(command);
        
        Logger.LogInformation("Domain deleted {Uid}", uid);

        return NoContent();
    }
}