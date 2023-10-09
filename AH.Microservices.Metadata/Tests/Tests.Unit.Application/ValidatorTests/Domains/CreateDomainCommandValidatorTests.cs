using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using Bogus;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Domains;

[TestClass]
public class CreateDomainCommandValidatorTests: BaseTest
{
    protected override void Init()
    {
        
    }

    protected override void Cleanup()
    {
        
    }

    [TestMethod]
    public async Task GivenCreateDomainCommandValidator_WhenEmptyName_ThenReturnEmptyNameMessage()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.Name, _ => string.Empty)
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateDomainCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.DomainNameNotEmpty));
    }
    
    [TestMethod]
    public async Task GivenCreateDomainCommandValidator_WhenNameTooLong_ThenReturnNameTooLongMessage()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.Name, f => f.Random.String2(251))
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateDomainCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.DomainNameMaxLength));
    }
    
    [TestMethod]
    public async Task GivenCreateDomainCommandValidator_WhenValidName_ThenReturnValid()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateDomainCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }
}