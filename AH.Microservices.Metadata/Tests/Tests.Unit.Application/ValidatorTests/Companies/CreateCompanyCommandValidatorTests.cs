using AH.Metadata.Application.Commands.Companies;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Domain.Entities;
using Bogus;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Companies;

[TestClass]
public class CreateCompanyCommandValidatorTests: BaseTest
{
    protected override void Init()
    {
        
    }

    protected override void Cleanup()
    {
        
    }

    [TestMethod]
    public async Task GivenCreateCompanyCommandValidator_WhenEmptyName_ThenReturnEmptyNameMessage()
    {
        // Arrange
        var dto = new CompanyDto
            {
                Name = string.Empty,
                Domain = new DomainDto{ UId = Guid.NewGuid() }
            }
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.CompanyNameNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenCreateCompanyCommandValidator_WhenNameTooLong_ThenReturnNameTooLongMessage()
    {
        // Arrange
        var dto = new CompanyDto
            {
                Name = new Faker().Random.String2(251),
                Domain = new DomainDto{ UId = Guid.NewGuid() }
            }
            .SetCommonDtoProps();
     
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.CompanyNameMaxLength));
    }
    
    [TestMethod]
    public async Task GivenCreateCompanyCommandValidator_WhenEmptyDomain_ThenReturnEmptyDomainMessage()
    {
        // Arrange
        var dto = new CompanyDto
            {
                Name = new Faker().Random.String2(250),
                Domain = new DomainDto{ UId = Guid.Empty }
            }
            .SetCommonDtoProps();
     
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.CompanyDomainUIdNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenCreateCompanyCommandValidator_WhenDomainNotFound_ThenReturnDomainNotFoundMessage()
    {
        // Arrange
        var dto = new CompanyDto
            {
                Name = new Faker().Random.String2(250),
                Domain = new DomainDto { UId = Guid.NewGuid() }
            }
            .SetCommonDtoProps();
     
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.CompanyDomainUIdNotFound));
    }
    
    [TestMethod]
    public async Task GivenCreateCompanyCommandValidator_WhenValid_ThenReturnValid()
    {
        // Arrange
        var domain = new Domain
        {
            UId = Guid.NewGuid(),
            Name = new Faker().Random.String2(250)
        }.SetCommonAuditableEntityProps();
        MetadataDbContext.Domains.Add(domain);
        await MetadataDbContext.SaveChangesAsync();
        var dto = new CompanyDto
            {
                Name = new Faker().Random.String2(250),
                Domain = new DomainDto { UId = domain.UId }
            }
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateCompanyCommandValidator(MetadataDbContext);
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
}