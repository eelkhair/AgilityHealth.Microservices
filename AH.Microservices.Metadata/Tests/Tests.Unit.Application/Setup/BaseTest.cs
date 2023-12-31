using AH.Metadata.Application.Interfaces;
using AH.Metadata.Persistence;
using AutoMapper;

namespace Tests.Unit.Application.Setup;

[TestCategory("Unit")]
[TestClass]
public abstract class BaseTest
{
    protected MockingHelper MockingHelper { get; } = new();
    protected MetadataDbContext MetadataDbContext { get; private set; } = null!;

    protected static IMapper Mapper => MapperSingleton.GetInstance().Mapper;

    [TestInitialize]
    public void TestClassInitialize()
    {
        MetadataDbContext = DbContextFactory.Create();
        Init();
    }
    
    [TestCleanup]
    public void TestClassDestroy()
    {
        Cleanup();
        DbContextFactory.Destroy(MetadataDbContext);
    }

    
    protected abstract void Init();
    protected abstract void Cleanup();
}