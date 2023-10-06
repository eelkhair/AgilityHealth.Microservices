using AH.Metadata.Application.Queries.Lists;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.QueryTests.Lists;

[TestClass]
public class ListSurveyTypesQueryTests : BaseTest
{
    protected override void Init()
    {
     
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenListSurveyTypesQuery_WhenValid_ThenReturnListOfSurveyTypes()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListSurveyTypesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListSurveyTypesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.AreEqual(result.Count, await MetadataDbContext.SurveyTypes.CountAsync());
    }
    
    [TestMethod]
    public async Task GivenListSurveyTypesQuery_WhenValid_ThenReturnValidItems()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListSurveyTypesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListSurveyTypesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        var firstSurveyTypeInResult = result[0];
       
        var firstSurveyTypeInDb = await MetadataDbContext.SurveyTypes.FirstOrDefaultAsync(x => x.Id == firstSurveyTypeInResult.Id);
        Assert.IsNotNull(firstSurveyTypeInDb);
        Assert.AreEqual(firstSurveyTypeInResult.Name, firstSurveyTypeInDb.Name);

       
    }
}