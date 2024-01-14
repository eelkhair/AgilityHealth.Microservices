using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyStakeholderTagsController : ControllerBase
{
    private readonly ICompanyStakeholderTagService _companyStakeholderTagService;
    public CompanyStakeholderTagsController(ICompanyStakeholderTagService companyStakeholderTagService)
    {
        _companyStakeholderTagService = companyStakeholderTagService;
    }
    
    [HttpGet("{companyStakeholderCategoryUId}")]
    public async Task<List<CompanyTagResponse>> GetCompanyStakeholderTags([FromRoute] Guid companyStakeholderCategoryUId)
        => await _companyStakeholderTagService.GetCompanyStakeholderTags(companyStakeholderCategoryUId);
}