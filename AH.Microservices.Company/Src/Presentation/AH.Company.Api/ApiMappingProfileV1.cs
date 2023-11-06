using AH.Company.Application.Dtos;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AutoMapper;

namespace AH.Company.Api;

/// <summary>
/// Mapping profile for API v1
/// </summary>
public class ApiMappingProfileV1 : Profile
{
    /// <summary>
    /// Constructor for API v1 mapping profile
    /// </summary>
    public ApiMappingProfileV1()
    {
        CreateMap<MasterTagCategoryResponse, MasterTagCategoryDto>();
        CreateMap<MasterTagWithCategoryAndParentTagResponse, MasterTagDto>()
            .ForMember(x => x.ParentMasterTag,
                opt => opt.MapFrom((src, dest) =>
                    src.ParentMasterTag?.UId == null ? null : new MasterTagDto { UId = src.ParentMasterTag.UId }));
        
    }
}