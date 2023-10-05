using AH.Metadata.Application.Commands.Lists;
using AH.Metadata.Application.Resources;
using AH.Metadata.Domain.Constants;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.ValidatorTests.Lists;

[TestClass]
public class GetListsCommandValidatorTests : BaseTest
{
    protected override void Init()
    {
    }

    protected override void Cleanup()
    {
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenValid_ThenReturnTrue()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new()
        {
            ListTypes.SurveyTypes,
            ListTypes.GrowthPlanStatuses,
            ListTypes.Industries,
            ListTypes.Countries
        });
        
        // Act
        var validator = new GetListsCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.IsValid);
    }

    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenInvalidListType_ThenReturnInvalidListTypeMessage()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new()
        {
            "InvalidListType"
        });

        // Act
        var validator = new GetListsCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == "'InvalidListType' doesn't exist"));
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenEmptyListType_ThenReturnEmptyListTypeMessage()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new());
        

        // Act
        var validator = new GetListsCommandValidator();
        var result = await validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Exists(x => x.ErrorMessage == ValidationMessages.List_ListTypeNotEmpty));
    }


}