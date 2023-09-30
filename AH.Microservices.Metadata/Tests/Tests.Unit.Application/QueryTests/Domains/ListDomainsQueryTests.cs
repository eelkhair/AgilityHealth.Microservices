using AH.Metadata.Application.Queries.Domains;
using AH.Metadata.Domain.Entities;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.QueryTests.Domains;

[TestClass]
public class ListDomainsQueryTests : BaseTest
{
    private const int NumberOfEntitiesInDb = 10;

    protected override void Init()
    {
        DbContextFactory.CreateBatchEntities(MetadataDbContext, () => new Domain
        {
            Name = Guid.NewGuid().ToString()
        }.SetCommonAuditableEntityProps(), NumberOfEntitiesInDb);
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenListDomainQuery_WhenValid_ThenListDomain()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListDomainsQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListDomainsQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
        Assert.AreEqual(NumberOfEntitiesInDb, result.Count);
    }
}