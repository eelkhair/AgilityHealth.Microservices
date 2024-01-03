using AH.Metadata.Application.Commands.Companies;
using AH.Metadata.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Companies;

[TestClass]
public class DeleteCompanyCommandTests : BaseTest
{
    private Company? _entityInDb;
    protected override void Init()
    {
        _entityInDb = DbContextFactory.CreateEntity(MetadataDbContext, new Company
        {
            Name = Guid.NewGuid().ToString(),
            Domain = new Domain()
            {
                Name= Guid.NewGuid().ToString(),
                UId = Guid.NewGuid()
            }.SetCommonAuditableEntityProps()
        }.SetCommonAuditableEntityProps());
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenDeleteCompanyCommand_WhenValid_ThenDeleteCompany()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, _entityInDb!.UId );
        
        // Act
        var handler = new DeleteCompanyCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsNotNull(result);
        
        var item = await MetadataDbContext.Companies.FirstOrDefaultAsync(x => x.UId == _entityInDb.UId, CancellationToken.None);
        Assert.IsNull(item);
    }
}