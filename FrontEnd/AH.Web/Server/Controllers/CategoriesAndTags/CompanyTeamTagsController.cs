using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyTeamTagsController : ControllerBase
{
    private readonly ICompanyTeamTagService _companyTeamTagService;

    public CompanyTeamTagsController(ICompanyTeamTagService companyTeamTagService)
    {
        _companyTeamTagService = companyTeamTagService;
    }

    [HttpGet("{companyTeamCategoryUId}")]
    public async Task<List<CompanyTagResponse>> GetCompanyTeamTags([FromRoute] Guid companyTeamCategoryUId)
    => await _companyTeamTagService.GetCompanyTeamTags(companyTeamCategoryUId); 
    
    
}