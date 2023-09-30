using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Domains;

[TestClass]
public class DeleteDomainCommandTests : BaseTest
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
    public async Task GivenDeleteDomainCommand_WhenValid_ThenDeleteDomain()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, _entityInDb!.UId );
        
        // Act
        var handler = new DeleteDomainCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsNotNull(result);
        
        var item = await MetadataDbContext.Domains.FirstOrDefaultAsync(x => x.UId == _entityInDb.UId, CancellationToken.None);
        Assert.IsNull(item);
    }
}