﻿using AH.Company.Application.Dtos;
using AH.Company.Shared.V1.Models.Tags.Responses;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.Metadata.Shared.V1.Models.Responses.MasterTagCategories;
using AH.Metadata.Shared.V1.Models.Responses.MasterTags;
using AutoMapper;
using CompanyResponse = AH.Company.Shared.V1.Models.Companies.Responses.CompanyResponse;
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
                opt => opt.MapFrom((src, _) =>
                    src.ParentMasterTagUId == null ? null : new MasterTagDto { UId = src.ParentMasterTagUId.Value }))  
            .ForMember(x => x.MasterTagCategory,
                opt => opt.MapFrom((src, _) =>
                    new MasterTagCategoryDto() { UId = src.MasterTagCategoryUId }));

        CreateMap<CompanyWithDomainResponse, CompanyDto>()
            .ForMember(x => x.DomainName, opt => opt.MapFrom(src => src.Domain.Name));
        CreateMap<CompanyDto, CompanyResponse>();
        CreateMap<MasterTagCategoryDto, CompanyMasterTagCategoryResponse>();
    }
}