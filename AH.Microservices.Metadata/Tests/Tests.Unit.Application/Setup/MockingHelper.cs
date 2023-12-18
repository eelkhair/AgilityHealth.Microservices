using System.Security.Claims;
using AH.Metadata.Domain.Constants;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Tests.Unit.Application.Setup;

public class MockingHelper
{
    public ILogger MockLogger { get; } = Substitute.For<ILogger>();

    public ClaimsPrincipal MockUser { get; } = Substitute.For<ClaimsPrincipal>();

    #region Users
    public void SetupCompanyAdminUser()
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, "TestHarness"),
            new(ClaimTypes.Role, AHClaimValues.CompanyAdmin)
        };
        MockUser.Claims.Returns(claims);
    }
    #endregion
}