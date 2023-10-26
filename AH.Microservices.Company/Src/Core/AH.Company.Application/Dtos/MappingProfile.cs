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
            .ForMember(x => x.CompanyTeamMemberCategories, opt => opt.Ignore());
    }
}