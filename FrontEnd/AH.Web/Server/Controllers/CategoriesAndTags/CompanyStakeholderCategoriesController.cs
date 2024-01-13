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
}