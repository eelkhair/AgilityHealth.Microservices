using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyTeamMemberCategoriesController : ControllerBase
{
    private readonly ICompanyTeamMemberCategoryService _companyTeamMemberCategoryService;

    public CompanyTeamMemberCategoriesController(ICompanyTeamMemberCategoryService companyTeamMemberCategoryService)
    {
        _companyTeamMemberCategoryService = companyTeamMemberCategoryService;
    }
    
    [HttpGet("{companyUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid companyUId)
    {
        var tags = await _companyTeamMemberCategoryService.GetCompanyTeamMemberCategories(companyUId);
        return Ok(tags);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CompanyCategoryResponse category)
    {
        var companyTeamCategory = await _companyTeamMemberCategoryService.CreateCompanyTeamMemberCategory(category);
        return Ok(companyTeamCategory);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CompanyCategoryResponse category)
    {
        var companyTeamCategory = await _companyTeamMemberCategoryService.UpdateCompanyTeamMemberCategory(category);
        return Ok(companyTeamCategory);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _companyTeamMemberCategoryService.DeleteCompanyTeamMemberCategory(uid);
        return Ok();
    }
}