using AH.Metadata.Shared.V1.Models.Responses.Companies;
using AH.User.Application.Dtos;
using AutoMapper;

namespace AH.User.Api;

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
        CreateMap<CompanyWithDomainResponse,CompanyDto> ();
    }
}