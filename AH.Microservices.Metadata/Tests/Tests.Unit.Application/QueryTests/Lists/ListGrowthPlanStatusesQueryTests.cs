using AH.Metadata.Application.Queries.Lists;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.QueryTests.Lists;

[TestClass]
public class ListGrowthPlanStatusesQueryTests : BaseTest
{
    protected override void Init()
    {
     
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenListGrowthPlanStatusesQuery_WhenValid_ThenReturnListOfGrowthPlanStatuses()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListGrowthPlanStatusesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListGrowthPlanStatusesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.AreEqual(result.Count, await MetadataDbContext.GrowthPlanStatuses.CountAsync());
    }
    
    [TestMethod]
    public async Task GivenListGrowthPlanStatusesQuery_WhenValid_ThenReturnValidItems()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListGrowthPlanStatusesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListGrowthPlanStatusesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        var firstGrowthPlanStatusInResult = result[0];
       
        var firstGrowthPlanStatusInDb = await MetadataDbContext.GrowthPlanStatuses.FirstOrDefaultAsync(x => x.Id == firstGrowthPlanStatusInResult.Id);
        Assert.IsNotNull(firstGrowthPlanStatusInDb);
        Assert.AreEqual(firstGrowthPlanStatusInResult.Status, firstGrowthPlanStatusInDb.Status);
       
    }
}
