using AH.Metadata.Application.Queries.Domains;
using AH.Metadata.Domain.Entities;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.QueryTests.Domains;

[TestClass]
public class GetDomainQueryTests : BaseTest
{
    private Domain? _entityInDb;
    protected override void Init()
    {
        _entityInDb = DbContextFactory.CreateEntity(MetadataDbContext, new Domain
        {
            Name = Guid.NewGuid().ToString()
        }.SetCommonAuditableEntityProps());
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenGetDomainQuery_WhenValid_ThenGetDomain()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetDomainQuery(MockingHelper.MockUser, MockingHelper.MockLogger, _entityInDb!.UId );
        
        // Act
        var handler = new GetDomainQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(_entityInDb.UId, result.UId);
    }
    
    [TestMethod]
    public async Task GivenGetDomainQuery_WhenInvalid_ThenReturnNull()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetDomainQuery(MockingHelper.MockUser, MockingHelper.MockLogger, Guid.NewGuid() );
        
        // Act
        var handler = new GetDomainQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsNull(result);
    }
}