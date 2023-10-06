namespace Tests.Unit.Application.Setup;
[TestClass]
public class SetupTests
{
    [TestMethod]
    public void DatabaseTest()
    {
        var context = DbContextFactory.Create();
        Assert.IsTrue(context.Countries.All(y=>y.UId != Guid.Empty));
        Assert.IsNotNull(context);
    }
}