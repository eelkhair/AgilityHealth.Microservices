using AH.Metadata.Shared.V1.Models.Responses.Domains;
using AH.Web.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DomainsController : ControllerBase
{
    private readonly IDomainService _domainService;
    public DomainsController(IDomainService domainService)
    {
        _domainService = domainService;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var tags = await _domainService.GetDomains();
        return Ok(tags);
    }

    [HttpPut]
    public async Task<ActionResult> Put(DomainResponse  domain)
    {
        var response = await _domainService.UpdateDomain(domain);
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Post(DomainResponse domain)
    {
        var response = await _domainService.CreateDomain(domain);
        return Ok(response);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _domainService.DeleteDomain(uid);
        return NoContent();
    }
}