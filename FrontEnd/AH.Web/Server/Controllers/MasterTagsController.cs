using AH.Metadata.Shared.V1.Models.Requests.Tags;
using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AH.Web.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MasterTagsController : ControllerBase
{
    private readonly IMasterTagService _masterTagService;
    public MasterTagsController(IMasterTagService masterTagService)
    {
        _masterTagService = masterTagService;
    }
    
    [HttpGet("MasterTags/Category/{categoryUId:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid categoryUId)
    {
        var tags =
            await _masterTagService.GetMasterTags(categoryUId);
        return Ok(tags);
    }

    [HttpPut("MasterTags/{masterTagUId:guid}")]
    public async Task<ActionResult> Put([FromRoute] Guid masterTagUId, MasterTagRequest masterTag)
    {
        var response = await _masterTagService.UpdateMasterTag(masterTagUId, masterTag);
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Post(MasterTagRequest category)
    {
        var response = await _masterTagService.CreateMasterTag(category);
        return Ok(response);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _masterTagService.DeleteMasterTag(uid);
        return NoContent();
    }
}