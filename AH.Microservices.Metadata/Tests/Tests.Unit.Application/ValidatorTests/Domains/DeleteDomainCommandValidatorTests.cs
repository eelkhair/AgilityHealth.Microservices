using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Resources;
using AH.Metadata.Domain.Entities;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Domains;

[TestClass]
public class DeleteDomainCommandValidatorTests : BaseTest
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
    public async Task GivenDeleteDomainCommandValidator_WhenValid_ThenReturnTrue()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, _entityInDb!.UId );
        
        // Act
        var validator = new DeleteDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
    
    [TestMethod]
    public async Task GivenDeleteDomainCommandValidator_WhenDomainDoesNotExist_ThenReturnDomainDoesNotExistMessage()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, Guid.NewGuid() );
        
        // Act
        var validator = new DeleteDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x=>x.ErrorMessage == ValidationMessages.DeleteDomain_UIdDoesNotExist));
    }
    
    [TestMethod]
    public async Task GivenDeleteDomainCommandValidator_WhenEmptyUid_ThenReturnEmptyUidMessage()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, Guid.Empty );
        
        // Act
        var validator = new DeleteDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x=>x.ErrorMessage == ValidationMessages.DeleteDomain_UIdNotEmpty));
    }
}