using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanySkillTagsController : ControllerBase
{
    private readonly ICompanySkillTagService _companySkillTagService;

    public CompanySkillTagsController(ICompanySkillTagService companySkillTagService)
    {
        _companySkillTagService = companySkillTagService;
    }
    
    [HttpGet("{companyUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid companyUId)
    {
        var tags = await _companySkillTagService.GetCompanySkillTags(companyUId);
        return Ok(tags);
    }
  
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CompanyTagResponse tag) =>
        Ok(await _companySkillTagService.CreateCompanySkillTag(tag));
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] CompanyTagResponse tag) =>
        Ok(await _companySkillTagService.UpdateCompanySkillTag(tag));
  
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _companySkillTagService.DeleteCompanySkillTag(uid);
        return NoContent();
    }
}