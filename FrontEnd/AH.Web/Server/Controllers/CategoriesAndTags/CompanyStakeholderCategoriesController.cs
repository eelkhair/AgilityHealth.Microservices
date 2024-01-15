using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyStakeholderCategoriesController : ControllerBase
{
    private readonly ICompanyStakeholderCategoryService _companyStakeholderCategoryService;

    public CompanyStakeholderCategoriesController(ICompanyStakeholderCategoryService companyStakeholderCategoryService)
    {
        _companyStakeholderCategoryService = companyStakeholderCategoryService;
    }
    
    [HttpGet("{companyUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid companyUId)
    {
        var tags = await _companyStakeholderCategoryService.GetCompanyStakeholderCategories(companyUId);
        return Ok(tags);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var companyStakeholderCategory = await _companyStakeholderCategoryService.CreateCompanyStakeholderCategory(category);
        return Ok(companyStakeholderCategory);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var companyStakeholderCategory = await _companyStakeholderCategoryService.UpdateCompanyStakeholderCategory(category);
        return Ok(companyStakeholderCategory);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _companyStakeholderCategoryService.DeleteCompanyStakeholderCategory(uid);
        return Ok();
    }
}