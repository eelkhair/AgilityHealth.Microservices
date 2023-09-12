using AH.Metadata.Api.Models.Domain;
using AH.Metadata.Application.Dtos;
using AutoMapper;

namespace AH.Metadata.Api.Models;

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
        CreateMap<DomainDto, AH.Metadata.Shared.Models.DomainDto>();
    }
}