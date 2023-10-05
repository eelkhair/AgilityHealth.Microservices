using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Dtos;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Domains;

[TestClass]
public class CreateDomainCommandTests : BaseTest
{
    protected override void Init()
    {
        
    }

    protected override void Cleanup()
    {

    }
    
    [TestMethod]
    public async Task GivenCreateDomainCommand_WhenValid_ThenCreateDomain()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var handler = new CreateDomainCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
         var item = await MetadataDbContext.Domains.FirstOrDefaultAsync(x => x.Name == dto.Name, CancellationToken.None);
        
         // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.UId);
        Assert.IsNotNull(item);
    }
}