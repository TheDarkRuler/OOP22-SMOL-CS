namespace Test;
using MySpace;
[TestClass]
public class UnitTest1
{
    GameState g;

    public UnitTest1()
    {
        this.g = new GameState();
    }

    [TestMethod]
    public void TestMethod1()
    {
        
        Assert.AreEqual(0,g.GetScore());
        Assert.AreEqual(1,1);
    }
}