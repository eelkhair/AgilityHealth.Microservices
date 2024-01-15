using AH.Company.Shared.V1.Models.Tags.Responses;
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
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var result = await _companySkillCategoryService.CreateCompanySkillCategory(category);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var result = await _companySkillCategoryService.UpdateCompanySkillCategory(category);
        return Ok(result);
    }
    
    [HttpDelete("{categoryUId:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid categoryUId)
    {
        await _companySkillCategoryService.DeleteCompanySkillCategory(categoryUId);
        return Ok();
    }
}