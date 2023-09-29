using System.Security.Claims;
using AH.Shared.Domain.Constants;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Tests.Unit.Application.Setup;

public class MockingHelper
{
    public MockingHelper()
    {
        MockUser = Substitute.For<ClaimsPrincipal>();
        MockLogger = Substitute.For<ILogger>();
    }

    public ILogger MockLogger { get; }

    public ClaimsPrincipal MockUser { get; }
    
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