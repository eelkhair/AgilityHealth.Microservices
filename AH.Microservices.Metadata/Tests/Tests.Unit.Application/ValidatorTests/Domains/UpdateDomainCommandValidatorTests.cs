using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Domain.Entities;
using Bogus;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Domains;

[TestClass]
public class UpdateDomainCommandValidatorTests : BaseTest
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
    public async Task GivenUpdateDomainCommandValidator_WhenValid_ThenReturnTrue()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.UId, _ => _entityInDb!.UId)
            .RuleFor(x=>x.Name, f=>f.Random.String2(250))
            .Generate().SetCommonDtoProps(false);
            
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
    
    [TestMethod]
    public async Task GivenUpdateDomainCommandValidator_WhenEmptyName_ThenReturnEmptyNameMessage()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.UId, _ => _entityInDb!.UId)
            .RuleFor(x => x.Name, _ => string.Empty)
            .Generate().SetCommonDtoProps(false);
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.DomainNameNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenUpdateDomainCommandValidator_WhenNameTooLong_ThenReturnNameTooLongMessage()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.UId, _ => _entityInDb!.UId)
            .RuleFor(x => x.Name, f => f.Random.String2(251))
            .Generate().SetCommonDtoProps(false);
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.DomainNameMaxLength));
    }
    
    [TestMethod]
    public async Task GivenUpdateDomainCommandValidator_WhenEmptyUId_ThenReturnEmptyUIdMessage()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.UId, _ => Guid.Empty)
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate().SetCommonDtoProps(false);
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.DomainUIdNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenUpdateDomainCommandValidator_WhenUIdDoesNotExist_ThenReturnUIdDoesNotExistMessage()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.UId, _ => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate().SetCommonDtoProps(false);
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateDomainCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.DomainUIdDoesNotExist));
    }
}