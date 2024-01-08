using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.Web.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var response = await _companyService.GetCompaniesForCurrentDomain();
        return Ok(response);
    }
    
    [HttpGet("/api/allcompanies")]
    public async Task<ActionResult> GetAllDomains()
    {
        var response = await _companyService.GetCompaniesForAllDomains();
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put(CompanyWithDomainResponse  company)
    {
        var response = await _companyService.UpdateCompany(company);
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Post(CompanyWithDomainResponse company)
    {
        var response = await _companyService.CreateCompany(company);
        return Ok(response);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _companyService.DeleteCompany(uid);
        return NoContent();
    }
}