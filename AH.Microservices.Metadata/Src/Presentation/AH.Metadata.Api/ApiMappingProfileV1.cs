﻿using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Shared.V1.Models.Requests.Companies;
using AH.Metadata.Shared.V1.Models.Requests.Domains;
using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.Metadata.Shared.V1.Models.Responses.Domains;
using AH.Metadata.Shared.V1.Models.Responses.Lists;
using AutoMapper;

namespace AH.Metadata.Api;

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
        CreateMap<CompanyDto, CompanyResponse>();
        CreateMap<CompanyDto, CompanyWithDomainResponse>();
        CreateMap<CreateCompanyRequest, CompanyDto>()
            .ForPath(x => x.Domain.UId, opt => opt.MapFrom(src => src.DomainUId));
        CreateMap<UpdateCompanyRequest, CompanyDto>();
        CreateMap<CountryDto, CountryResponse>();
        CreateMap<DomainDto, DomainResponse>();
        CreateMap<DomainDto, DomainWithCompaniesResponse>();
        CreateMap<DomainRequest, DomainDto>();
        CreateMap<GrowthPlanStatusDto, GrowthPlanStatusResponse>();
        CreateMap<IndustryDto, IndustryResponse>();
        CreateMap<SurveyTypeDto, SurveyTypeResponse>();
    }
}

/// <summary>
/// Extension methods for mapping selection lists
/// </summary>
public static class MapperExtensions
{
    /// <summary>
    /// Map selection lists
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="listDto"></param>
    /// <returns></returns>
    public static ListResponse MapLists(this IMapper mapper, ListDto listDto)
    {
        var result = new ListResponse();
        foreach(var item in listDto.Data)
        {
            switch (item.Key)
            {
                case ListTypes.Countries:
                    result.Countries = mapper.Map<List<CountryResponse>>(item.Value);
                    break;
                
                case ListTypes.SurveyTypes:
                    result.SurveyTypes = mapper.Map<List<SurveyTypeResponse>>(item.Value);
                    break;
                
                case ListTypes.Industries:
                    result.Industries = mapper.Map<List<IndustryResponse>>(item.Value);
                    break;
                
                case ListTypes.GrowthPlanStatuses:
                    result.GrowthPlanStatuses = mapper.Map<List<GrowthPlanStatusResponse>>(item.Value);
                    break;
            }
        }
        return result;
    }
}