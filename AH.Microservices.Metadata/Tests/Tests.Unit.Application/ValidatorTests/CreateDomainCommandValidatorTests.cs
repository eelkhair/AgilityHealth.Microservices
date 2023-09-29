using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Resources;
using Bogus;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests;

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
            .RuleFor(x => x.Name, f => string.Empty)
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var validator = new CreateDomainCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == ValidationMessages.CreateDomain_NameNotEmpty));
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
        Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == ValidationMessages.CreateDomain_NameMaxLength));
    }
}