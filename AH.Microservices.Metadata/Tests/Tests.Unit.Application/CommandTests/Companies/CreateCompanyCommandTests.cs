using AH.Metadata.Application.Commands.Companies;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Tests.Unit.Application.Setup;

namespace Tests.Unit.Application.CommandTests.Companies;

[TestClass]
public class CreateCompanyCommandTests : BaseTest
{
    private Guid _uid;
    protected override void Init()
    {
        var domain = new Domain{ UId = Guid.NewGuid(), Name = Guid.NewGuid().ToString() }.SetCommonAuditableEntityProps();
        MetadataDbContext.Domains.Add(domain);
        MetadataDbContext.SaveChanges();
        _uid = domain.UId;
    }

    protected override void Cleanup()
    {

    }
    
    [TestMethod]
    public async Task GivenCreateCompanyCommand_WhenValid_ThenCreateCompany()
    {
        // Arrange
        var dto = new Faker<CompanyDto>()
            .RuleFor(x => x.Name, f => f.Random.String2(250))
            .Generate()
            .SetCommonDtoProps();
        MockingHelper.SetupCompanyAdminUser();
        
        dto.Domain = new DomainDto
        {
            UId = _uid
        };
        var command = new CreateCompanyCommand(MockingHelper.MockUser, MockingHelper.MockLogger, dto );
        
        // Act
        var handler = new CreateCompanyCommandHandler(MetadataDbContext, Mapper);
        var result = await handler.Handle(command, CancellationToken.None);
        var item = await MetadataDbContext.Companies.FirstOrDefaultAsync(x => x.Name == dto.Name, CancellationToken.None);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.UId);
        Assert.IsNotNull(item);
    }
}