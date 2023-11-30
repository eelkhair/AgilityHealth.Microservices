using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;

namespace AH.Web.Services.Interfaces;

public interface IMasterTagCategoryService
{
    Task<List<MasterTagCategoryResponse>> GetMasterTagCategories();
}