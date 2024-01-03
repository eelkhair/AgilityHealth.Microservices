using System.Text.Json;
using AH.Metadata.Api.MessageSenders.Interfaces;
using AH.Metadata.Application.Commands.Companies;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Queries.Companies;
using AH.Metadata.Shared.V1.Models.Requests.Companies;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Companies Controller
/// </summary>
public class CompaniesController : BaseController
{
    private readonly ICompaniesMessageSender MessageSender;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="mediator"></param>
    public CompaniesController(IMapper mapper, ILogger<CompaniesController> logger, IMediator mediator, ICompaniesMessageSender sender) : base(mapper, logger, mediator)
    {
        MessageSender = sender;
    }
    
    /// <summary>
    /// Get a list of all companies
    /// </summary>
    /// <response code="200">Successfully retrieved list of companies</response>
    /// <response code="404">No companies exist</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<CompanyResponse>), StatusCodes.Status200OK)]
    [HttpGet]   
    public async Task<IActionResult> GetCompanies()
    {
        Logger.LogInformation("Getting all companies");
        var query = new ListCompaniesQuery(User, Logger);
        var companies = await Mediator.Send(query);
        if(companies.Count == 0) return NotFound();
        
        var model = Mapper.Map<List<CompanyResponse>>(companies);
        Logger.LogInformation("{Count} companies found.{Data}", companies.Count, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Get a company by uid
    /// </summary>
    /// <param name="uid">The uid of the company to retrieve</param>
    /// <response code="200">Successfully retrieved company</response>
    /// <response code="404">Company not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(CompanyWithDomainResponse), StatusCodes.Status200OK)]
    [HttpGet("{uid:guid}")]
    public async Task<IActionResult> GetCompany(Guid uid)
    {
        Logger.LogInformation("Getting company with uid {Uid}", uid);
        var query = new GetCompanyQuery(User, Logger, uid);
        var company = await Mediator.Send(query);
        if(company == null) return NotFound();
        
        var model = Mapper.Map<CompanyWithDomainResponse>(company);
        Logger.LogInformation("Company with uid {Uid} found.{Data}", uid, JsonSerializer.Serialize(model));
        
        return Ok(model);
    }
    
    /// <summary>
    /// Create a new company
    /// </summary>
    /// <param name="model">The company to create</param>
    /// <response code="201">Successfully created company</response>
    /// <response code="400">Invalid request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(CompanyWithDomainResponse), StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest model)
    {
        var dto = Mapper.Map<CompanyDto>(model);
        Logger.LogInformation("Creating company {Data}", JsonSerializer.Serialize(model));
        
        var command = new CreateCompanyCommand(User, Logger, dto);
        var company = await Mediator.Send(command);
       
        var companyModel = Mapper.Map<CompanyWithDomainResponse>(company);
        Logger.LogInformation("Company created {Data}", JsonSerializer.Serialize(companyModel));
        
        await MessageSender.SendCreateCompanyMessageAsync(User, companyModel);
        return CreatedAtAction(nameof(GetCompany), new {uid = company.UId}, companyModel);
    }
    
    /// <summary>
    /// Update a company
    /// </summary>
    /// <param name="uid">The uid of the company to update</param>
    /// <param name="model">The company to update</param>
    /// <response code="200">Successfully updated company</response>
    /// <response code="400">Invalid request</response>
    /// <response code="404">Company not found</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
    [HttpPut("{uid:guid}")]
    public async Task<IActionResult> UpdateCompany(Guid uid, [FromBody] UpdateCompanyRequest model)
    {
        Logger.LogInformation("Updating company {Data}", JsonSerializer.Serialize(model));
        var dto = Mapper.Map<CompanyDto>(model);
        dto.UId = uid;
        
        var command = new UpdateCompanyCommand(User, Logger, dto);
        var company = await Mediator.Send(command);
        
        var companyModel = Mapper.Map<CompanyWithDomainResponse>(company);
        Logger.LogInformation("Company updated {Data}", JsonSerializer.Serialize(companyModel));
        
        await MessageSender.SendUpdateCompanyMessageAsync(User, companyModel);
        return Ok(companyModel);
    }
    
    /// <summary>
    /// Delete a company
    /// </summary>
    /// <param name="uid">The uid of the company to delete</param>
    /// <response code="204">Successfully deleted company</response>
    /// <response code="400">Invalid request</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [HttpDelete("{uid:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCompany(Guid uid)
    {
        Logger.LogInformation("Deleting company {Uid}", uid);
        var command = new DeleteCompanyCommand(User, Logger, uid);
        var response = await Mediator.Send(command);
        
        Logger.LogInformation("company deleted {Uid}", uid);    
        
        var companyModel = Mapper.Map<CompanyWithDomainResponse>(response);
        await MessageSender.SendDeleteCompanyMessageAsync(User, companyModel);
        return NoContent();
    }
}