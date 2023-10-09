using AH.Metadata.Application.Commands.Lists;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Lists;

[TestClass]
public class GetListsCommandTests : BaseTest
{
    protected override void Init()
    {
        
    }

    protected override void Cleanup()
    {
      
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandHandle_WhenAllTypesSelected_ThenReturnValidResults()
    {
        // Arrange
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            ListTypes.SurveyTypes,
            ListTypes.GrowthPlanStatuses,
            ListTypes.Industries,
            ListTypes.Countries
        });
        
        // Act
        var handler = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.Count == 4);
        Assert.IsTrue(((List<SurveyTypeDto>)result.Data[ListTypes.SurveyTypes]).Count == await MetadataDbContext.SurveyTypes.CountAsync()); 
        Assert.IsTrue(((List<GrowthPlanStatusDto>)result.Data[ListTypes.GrowthPlanStatuses]).Count == await MetadataDbContext.GrowthPlanStatuses.CountAsync());
        Assert.IsTrue(((List<IndustryDto>)result.Data[ListTypes.Industries]).Count == await MetadataDbContext.Industries.CountAsync());
        Assert.IsTrue(((List<CountryDto>)result.Data[ListTypes.Countries]).Count == await MetadataDbContext.Countries.CountAsync());
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandHandle_WhenSomeTypesSelected_ThenReturnValidResults()
    {
        // Arrange
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            ListTypes.SurveyTypes,
            ListTypes.GrowthPlanStatuses
        });
        
        // Act
        var handler = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.Count == 2);
        Assert.IsTrue(((List<SurveyTypeDto>)result.Data[ListTypes.SurveyTypes]).Count == await MetadataDbContext.SurveyTypes.CountAsync()); 
        Assert.IsTrue(((List<GrowthPlanStatusDto>)result.Data[ListTypes.GrowthPlanStatuses]).Count == await MetadataDbContext.GrowthPlanStatuses.CountAsync());
        Assert.IsFalse(result.Data.ContainsKey(ListTypes.Industries));   
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandHandle_WhenNoTypesSelected_ThenReturnValidResults()
    {
        // Arrange
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>());
        
        // Act
        var handler = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.Count == 0);
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandHandle_WhenInvalidTypeSelected_ThenReturnValidResults()
    {
        // Arrange
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            "InvalidListType"
        });
        
        // Act
        var handler = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.Count == 0);
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenCountriesSelected_ThenReturnCountries()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            ListTypes.Countries
        });
        
        // Act
        var validator = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await validator.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.ContainsKey(ListTypes.Countries));
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenSurveyTypesSelected_ThenReturnSurveyTypes()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            ListTypes.SurveyTypes
        });
        
        // Act
        var validator = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await validator.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.ContainsKey(ListTypes.SurveyTypes));
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenIndustriesSelected_ThenReturnIndustries()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            ListTypes.Industries
        });
        
        // Act
        var validator = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await validator.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.ContainsKey(ListTypes.Industries));
    }
    
    [TestMethod]
    public async Task GivenGetListsCommandValidator_WhenGrowthPlanStatusesSelected_ThenReturnGrowthPlanStatuses()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new GetListsCommand(MockingHelper.MockUser, MockingHelper.MockLogger, new List<string>
        {
            ListTypes.GrowthPlanStatuses
        });
        
        // Act
        var validator = new GetListsCommandHandler(MetadataDbContext, Mapper);
        var result = await validator.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.IsTrue(result.Data.ContainsKey(ListTypes.GrowthPlanStatuses));
    }
}