using AH.Metadata.Application.Commands.Companies;

using AH.Metadata.Application.Resources;
using AH.Metadata.Domain.Entities;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Companies;

[TestClass]
public class DeleteCompanyCommandValidatorTests : BaseTest
{
    private Company? _entityInDb;
    protected override void Init()
    {
        var domain = DbContextFactory.CreateEntity(MetadataDbContext, new Domain
        {
            Name = Guid.NewGuid().ToString()
        }.SetCommonAuditableEntityProps());
        
        _entityInDb = DbContextFactory.CreateEntity(MetadataDbContext, new Company
        {
            Name = Guid.NewGuid().ToString(),
            DomainId = domain.Id
        }.SetCommonAuditableEntityProps());
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenDeleteCompanyCommandValidator_WhenValid_ThenReturnTrue()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, _entityInDb!.UId );
        
        // Act
        var validator = new DeleteCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
    
    [TestMethod]
    public async Task GivenDeleteCompanyCommandValidator_WhenCompanyDoesNotExist_ThenReturnCompanyDoesNotExistMessage()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, Guid.NewGuid() );
        
        // Act
        var validator = new DeleteCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x=>x.ErrorMessage == ValidationMessages.Company_UIdDoesNotExist));
    }
    
    [TestMethod]
    public async Task GivenDeleteCompanyCommandValidator_WhenEmptyUid_ThenReturnEmptyUidMessage()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new DeleteCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, Guid.Empty );
        
        // Act
        var validator = new DeleteCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x=>x.ErrorMessage == ValidationMessages.Company_UIdNotEmpty));
    }
}