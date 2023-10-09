using AH.Metadata.Application.Queries.Lists;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.QueryTests.Lists;

[TestClass]
public class ListIndustriesQueryTests : BaseTest
{
    protected override void Init()
    {
        
    }

    protected override void Cleanup()
    {
       
    }
    
    [TestMethod]
    public async Task GivenListIndustriesQuery_WhenValid_ThenReturnListOfIndustries()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListIndustriesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListIndustriesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.AreEqual(result.Count, await MetadataDbContext.Industries.CountAsync());
    }
    
    [TestMethod]
    public async Task GivenListIndustriesQuery_WhenValid_ThenReturnValidItems()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListIndustriesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListIndustriesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        var firstIndustryInResult = result.FirstOrDefault(x=>x.IsDefault) ?? result[0];
       
        var firstIndustryInDb = await MetadataDbContext.Industries.FirstOrDefaultAsync(x => x.UId == firstIndustryInResult.UId);
        Assert.IsNotNull(firstIndustryInDb);
        Assert.AreEqual(firstIndustryInResult.Name, firstIndustryInDb.Name);
        Assert.AreEqual(firstIndustryInResult.IsDefault, firstIndustryInDb.IsDefault);
    }
    
}