using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyTeamTagsController : ControllerBase
{
    private readonly ICompanyTeamTagService _companyTeamTagService;

    public CompanyTeamTagsController(ICompanyTeamTagService companyTeamTagService)
    {
        _companyTeamTagService = companyTeamTagService;
    }

    [HttpGet("{companyTeamCategoryUId}")]
    public async Task<List<CompanyTagResponse>> GetCompanyTeamTags([FromRoute] Guid companyTeamCategoryUId)
    => await _companyTeamTagService.GetCompanyTeamTags(companyTeamCategoryUId);

    [HttpPost]
    public async Task<CompanyTagResponse> CreateCompanyTeamTag([FromBody] CompanyTagResponse tag)=>
        await _companyTeamTagService.CreateCompanyTeamTag(tag);
    
    [HttpPut]
    public async Task<CompanyTagResponse> UpdateCompanyTeamTag([FromBody] CompanyTagResponse tag)=>
        await _companyTeamTagService.UpdateCompanyTeamTag(tag);
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _companyTeamTagService.DeleteCompanyTeamTag(uid);
        return NoContent();
    }
    
}