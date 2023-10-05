using AH.Metadata.Application.Commands.Companies;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Resources;
using AH.Metadata.Domain.Entities;
using Bogus;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Companies;

[TestClass]
public class UpdateCompanyCommandValidatorTests : BaseTest
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
    public async Task GivenUpdateCompanyCommandValidator_WhenValid_ThenReturnTrue()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.UId, _ => _entityInDb!.UId)
            .RuleFor(x=>x.Name, f=>f.Random.String2(250))
            .Generate().SetCommonDtoProps(false);
            
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
    
    [TestMethod]
    public async Task GivenUpdateCompanyCommandValidator_WhenEmptyName_ThenReturnEmptyNameMessage()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.UId, _ => _entityInDb!.UId)
            .RuleFor(x => x.Name, _ => string.Empty)
            .Generate().SetCommonDtoProps(false);
        
        var command = new UpdateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.Company_NameNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenUpdateCompanyCommandValidator_WhenNameTooLong_ThenReturnNameTooLongMessage()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.UId, _ => _entityInDb!.UId)
            .RuleFor(x => x.Name, f => f.Random.String2(251))
            .Generate().SetCommonDtoProps(false);
        
        var command = new UpdateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.Company_NameMaxLength));
    }
    
    [TestMethod]
    public async Task GivenUpdateCompanyCommandValidator_WhenEmptyUId_ThenReturnEmptyUIdMessage()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.UId, _ => Guid.Empty)
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate().SetCommonDtoProps(false);
        
        var command = new UpdateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.Company_UIdNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenUpdateCompanyCommandValidator_WhenUIdDoesNotExist_ThenReturnUIdDoesNotExistMessage()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.UId, _ => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate().SetCommonDtoProps(false);
        MockingHelper.SetupCompanyAdminUser();
        var command = new UpdateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new UpdateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.Company_UIdDoesNotExist));
    }
}