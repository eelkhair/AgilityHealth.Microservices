using AH.Company.Domain.Entities;
using AutoMapper;

namespace AH.Company.Application.Dtos;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<MasterTagCategoryDto, MasterTagCategory>()
            .ForMember(x => x.MasterTags, opt => opt.Ignore())
            .ForMember(x => x.CompanyTeamCategories, opt => opt.Ignore())
            .ForMember(x => x.CompanySkillCategories, opt => opt.Ignore())
            .ForMember(x => x.CompanyStakeholderCategories, opt => opt.Ignore())
            .ForMember(x => x.CompanyTeamMemberCategories, opt => opt.Ignore())
            .ReverseMap();
        
        CreateMap<MasterTagDto, MasterTag>()
            .ForMember(x => x.MasterTagCategory, opt => opt.Ignore())
            .ForMember(x => x.CompanyTeamTags, opt => opt.Ignore())
            .ForMember(x => x.CompanySkillTags, opt => opt.Ignore())
            .ForMember(x => x.CompanyStakeholderTags, opt => opt.Ignore())
            .ForMember(x => x.CompanyTeamMemberTags, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<CompanyDto, Domain.Entities.Company>().ReverseMap();
    }
}