using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanySkillCategoriesController : ControllerBase
{
    private readonly ICompanySkillCategoryService _companySkillCategoryService;

    public CompanySkillCategoriesController(ICompanySkillCategoryService companySkillCategoryService)
    {
        _companySkillCategoryService = companySkillCategoryService;
    }
    
    [HttpGet("{companyUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid companyUId)
    {
        var tags = await _companySkillCategoryService.GetCompanySkillCategories(companyUId);
        return Ok(tags);
    }
}