using AH.Metadata.Application.Queries.Lists;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.QueryTests.Lists;

[TestClass]
public class ListCountriesQueryTests : BaseTest
{
    protected override void Init()
    {
     
    }

    protected override void Cleanup()
    {
        
    }
    
    [TestMethod]
    public async Task GivenListCountriesQuery_WhenValid_ThenReturnListOfCountries()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListCountriesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListCountriesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.AreEqual(result.Count, await MetadataDbContext.Countries.CountAsync());
    }
    
    [TestMethod]
    public async Task GivenListCountriesQuery_WhenValid_ThenReturnValidItems()
    {
        // Arrange
        MockingHelper.SetupCompanyAdminUser();
        var command = new ListCountriesQuery(MockingHelper.MockUser, MockingHelper.MockLogger);
        
        // Act
        var handler = new ListCountriesQueryHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        var firstCountryInResult = result[0];
       
        var firstCountryInDb = await MetadataDbContext.Countries.FirstOrDefaultAsync(x => x.Id == firstCountryInResult.Id);
        Assert.IsNotNull(firstCountryInDb);
        Assert.AreEqual(firstCountryInResult.Name, firstCountryInDb.Name);
        Assert.AreEqual(firstCountryInResult.Code, firstCountryInDb.Code);
       
    }
}