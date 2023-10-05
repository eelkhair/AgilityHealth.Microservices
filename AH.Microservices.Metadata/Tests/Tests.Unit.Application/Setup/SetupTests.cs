namespace Tests.Unit.Application.Setup;
[TestClass]
public class SetupTests
{
    [TestMethod]
    public void DatabaseTest()
    {
        var context = DbContextFactory.Create();
        
        Assert.IsNotNull(context);
    }
}