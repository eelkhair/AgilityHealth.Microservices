using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

namespace AH.Web.Server.Services.Interfaces.CategoriesAndTags;

public interface IMasterTagCategoryService
{
    Task<List<MasterTagCategoryResponse>> GetMasterTagCategories();
    Task<MasterTagCategoryResponse> UpdateMasterTagCategory(MasterTagCategoryResponse category);
    Task<MasterTagCategoryResponse> CreateMasterTagCategory(MasterTagCategoryResponse category);
    Task DeleteMasterTagCategory(Guid uid);
}