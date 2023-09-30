using AH.Metadata.Application.Commands.Domains;
using AH.Metadata.Application.Dtos;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Domains;

[TestClass]
public class UpdateDomainCommandTests : BaseTest
{
    protected override void Init()
    {
    }

    protected override void Cleanup()
    {
    }
    
    [TestMethod]
    public async Task GivenUpdateDomainCommand_WhenValid_ThenUpdateDomain()
    {
        // Arrange
        var dto = new Faker<DomainDto>()
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        var handler = new CreateDomainCommandHandler(MetadataDbContext, Mapper);
        var updateDto = await handler.Handle(command, CancellationToken.None);
        var updateCommand = new UpdateDomainCommand(MockingHelper.MockUser, MockingHelper.MockLogger, updateDto)
            {
                Domain = { Name = "Updated Name" }
            };

        // Act
        var updateHandler = new UpdateDomainCommandHandler(MetadataDbContext, Mapper);
        await updateHandler.Handle(updateCommand, CancellationToken.None);
        
        // Assert
        var item = await MetadataDbContext.Domains.FirstOrDefaultAsync(x => x.UId == updateCommand.Domain.UId, CancellationToken.None);
        Assert.IsNotNull(item);
        Assert.AreEqual(updateCommand.Domain.Name, item.Name);
    }
}