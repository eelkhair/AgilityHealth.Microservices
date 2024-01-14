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
}