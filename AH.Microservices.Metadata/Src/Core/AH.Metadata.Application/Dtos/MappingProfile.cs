using AutoMapper;

namespace AH.Metadata.Application.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Domain, DomainDto>().ReverseMap();
    }
}