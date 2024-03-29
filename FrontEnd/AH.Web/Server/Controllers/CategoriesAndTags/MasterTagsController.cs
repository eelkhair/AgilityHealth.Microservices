using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AH.Web.Server.Services.Interfaces.CategoriesAndTags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers.CategoriesAndTags;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MasterTagsController : ControllerBase
{
    private readonly IMasterTagService _masterTagService;
    public MasterTagsController(IMasterTagService masterTagService)
    {
        _masterTagService = masterTagService;
    }
    
    [HttpGet("Category/{categoryUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid categoryUId)
    {
        var tags =
            await _masterTagService.GetMasterTags(categoryUId);
        return Ok(tags);
    }

    [HttpPut]
    public async Task<ActionResult> Put(MasterTagWithCategoryAndParentTagResponse masterTag)
    {
        var response = await _masterTagService.UpdateMasterTag(masterTag);
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Post(MasterTagWithCategoryAndParentTagResponse tag)
    {
        var response = await _masterTagService.CreateMasterTag(tag);
        return Ok(response);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _masterTagService.DeleteMasterTag(uid);
        return NoContent();
    }
}