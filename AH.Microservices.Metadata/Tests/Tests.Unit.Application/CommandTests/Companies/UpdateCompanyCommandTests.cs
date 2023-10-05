using AH.Metadata.Application.Commands.Companies;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Companies;

[TestClass]
public class UpdateCompanyCommandTests : BaseTest
{
    private Guid Uid { get; set; }
    protected override void Init()
    {
        var domain = new Domain{ UId = Guid.NewGuid(), Name = Guid.NewGuid().ToString() }.SetCommonAuditableEntityProps();
        MetadataDbContext.Domains.Add(domain);
        MetadataDbContext.SaveChanges();
        Uid = domain.UId;
    }

    protected override void Cleanup()
    {
    }
    
    [TestMethod]
    public async Task GivenUpdateCompanyCommand_WhenValid_ThenUpdateCompany()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate()
            .SetCommonDtoProps();
        dto.Domain = new DomainDto();
        dto.Domain.UId = Uid;
        MockingHelper.SetupCompanyAdminUser();
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        var handler = new CreateCompanyCommandHandler(MetadataDbContext, Mapper);
        var updateDto = await handler.Handle(command, CancellationToken.None);
        var updateCommand = new UpdateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, updateDto)
            {
                Company = { Name = "Updated Name" }
            };

        // Act
        var updateHandler = new UpdateCompanyCommandHandler(MetadataDbContext, Mapper);
        await updateHandler.Handle(updateCommand, CancellationToken.None);
        
        // Assert
        var item = await MetadataDbContext.Companies.FirstOrDefaultAsync(x => x.UId == updateCommand.Company.UId, CancellationToken.None);
        Assert.IsNotNull(item);
        Assert.AreEqual(updateCommand.Company.Name, item.Name);
    }
}