using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyTeamCategoriesController : ControllerBase
{
    private readonly ICompanyTeamCategoryService _companyTeamCategoryService;

    public CompanyTeamCategoriesController(ICompanyTeamCategoryService companyTeamCategoryService)
    {
        _companyTeamCategoryService = companyTeamCategoryService;
    }
    
    [HttpGet("{companyUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid companyUId)
    {
        var tags = await _companyTeamCategoryService.GetCompanyTeamCategories(companyUId);
        return Ok(tags);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var companyTeamCategory = await _companyTeamCategoryService.CreateCompanyTeamCategory(category);
        return Ok(companyTeamCategory);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var companyTeamCategory = await _companyTeamCategoryService.UpdateCompanyTeamCategory(category);
        return Ok(companyTeamCategory);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _companyTeamCategoryService.DeleteCompanyTeamCategory(uid);
        return Ok();
    }
}