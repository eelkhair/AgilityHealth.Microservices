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
}