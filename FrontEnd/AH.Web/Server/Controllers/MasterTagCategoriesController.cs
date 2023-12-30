using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Web.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AH.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MasterTagCategoriesController : ControllerBase
{
    private readonly IMasterTagCategoryService _masterTagCategoryService;
    public MasterTagCategoriesController(IMasterTagCategoryService masterTagCategoryService)
    {
        _masterTagCategoryService = masterTagCategoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var categories =
            await _masterTagCategoryService.GetMasterTagCategories();
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult> Put(MasterTagCategoryResponse category)
    {
        var response = await _masterTagCategoryService.UpdateMasterTagCategory(category);
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult> Post(MasterTagCategoryResponse category)
    {
        var response = await _masterTagCategoryService.CreateMasterTagCategory(category);
        return Ok(response);
    }
    
    [HttpDelete("{uid:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid uid)
    {
        await _masterTagCategoryService.DeleteMasterTagCategory(uid);
        return NoContent();
    }
}