using AH.Metadata.Api.Models.Domain;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Shared.V1.Models.Responses;
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
        CreateMap<DomainDto, GetDomainViewModel>();
        CreateMap<CreateDomainViewModel, DomainDto>();
        CreateMap<UpdateDomainViewModel, DomainDto>();
        CreateMap<CountryDto, CountryResponse>();
        CreateMap<SurveyTypeDto, SurveyTypeResponse>();
        CreateMap<IndustryDto, IndustryResponse>();
        CreateMap<GrowthPlanStatusDto, GrowthPlanStatusResponse>();
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
    /// <param name="selectionListDto"></param>
    /// <returns></returns>
    public static SelectionListResponse MapSelectionList(this IMapper mapper, SelectionListDto selectionListDto)
    {
        var result = new SelectionListResponse();
        foreach(var item in selectionListDto.Data)
        {
            switch (item.Key)
            {
                case SelectionListTypes.Countries:
                    result.Countries = mapper.Map<List<CountryResponse>>(item.Value);
                    break;
                
                case SelectionListTypes.SurveyTypes:
                    result.SurveyTypes = mapper.Map<List<SurveyTypeResponse>>(item.Value);
                    break;
                
                case SelectionListTypes.Industries:
                    result.Industries = mapper.Map<List<IndustryResponse>>(item.Value);
                    break;
                
                case SelectionListTypes.GrowthPlanStatuses:
                    result.GrowthPlanStatuses = mapper.Map<List<GrowthPlanStatusResponse>>(item.Value);
                    break;
            }
        }
        return result;
    }
}