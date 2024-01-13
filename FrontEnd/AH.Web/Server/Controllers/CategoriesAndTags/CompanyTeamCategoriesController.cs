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
}