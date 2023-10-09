using AH.Metadata.Domain.Entities;
using AutoMapper;

namespace AH.Metadata.Application.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Domain, DomainDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap()
            .ForMember(x=>x.Domain, opt=> opt.Ignore());
        CreateMap<Industry, IndustryDto>().ReverseMap();
        CreateMap<GrowthPlanStatus, GrowthPlanStatusDto>().ReverseMap();
        CreateMap<SurveyType, SurveyTypeDto>().ReverseMap();
        CreateMap<MasterTagCategory, MasterTagCategoryDto>().ReverseMap()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.CreatedAt, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore());
        CreateMap<MasterTag, MasterTagDto>().ReverseMap();
    }
}