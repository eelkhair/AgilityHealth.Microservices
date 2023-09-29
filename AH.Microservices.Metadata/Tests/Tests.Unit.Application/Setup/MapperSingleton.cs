using AH.Metadata.Application.Dtos;
using AutoMapper;

namespace Tests.Unit.Application.Setup;

public sealed class MapperSingleton
{
    private static readonly MapperSingleton Instance = new();

    private MapperSingleton()
    {
        var mapperConfig = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); });
        Mapper = mapperConfig.CreateMapper();
    }

    public IMapper Mapper { get; }

    public static MapperSingleton GetInstance()
    {
        return Instance;
    }
}