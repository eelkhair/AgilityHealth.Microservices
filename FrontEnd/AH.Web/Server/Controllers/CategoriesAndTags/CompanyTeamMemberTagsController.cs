using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyTeamMemberTagsController : ControllerBase
{
    private readonly ICompanyTeamMemberTagService _companyTeamMemberTagService;

    public CompanyTeamMemberTagsController(ICompanyTeamMemberTagService companyTeamMemberTagService)
    {
        _companyTeamMemberTagService = companyTeamMemberTagService;
    }

    [HttpGet("{companyTeamMemberCategoryUId}")]
    public async Task<List<CompanyTagResponse>> GetCompanyTeamMemberTags([FromRoute] Guid companyTeamMemberCategoryUId)
        => await _companyTeamMemberTagService.GetCompanyTeamMemberTags(companyTeamMemberCategoryUId); 
    
    
}