namespace Test;
using MySpace;

[TestClass]
public class GameStateTest
{
    private GameState _g;
    private World _world;
    private const int Points = 100;

    public GameStateTest()
    {
        _world = new World();
        _g = new GameState(_world);
    }

    [TestMethod]
    public void InitGameTest()
    {
        _g.InitGame();
        Assert.AreEqual(1, _g.GetWorld().GetEntities().Where(e => e.GetType() == Type.HEALTH).Count());
        Assert.AreEqual(1, _g.GetWorld().GetEntities().Where(e => e.GetType() == Type.PLAYER).Count());
        Assert.AreEqual(1, _g.GetWorld().GetEntities().Where(e => e.GetType() == Type.WEAPON).Count());
        Assert.AreEqual(1, _g.GetWorld().GetEntities().Where(e => e.GetType() == Type.WALL).Count());
    }

    [TestMethod]
    public void GameOverTest()
    {
        _g.InitGame();
        Assert.IsFalse(_g.IsGameOver());

        _g.GetWorld().Remove(_g.GetWorld().GetEntities().Where(e => e.GetType() == Type.HEALTH).First());
        Assert.IsTrue(_g.IsGameOver());
    }

    [TestMethod]
    public void ScoreTest()
    {
        Assert.AreEqual(0, _g.GetScore());

        _g.GetWorld().IncScore(Points);
        Assert.AreNotEqual(0, _g.GetScore());
        Assert.AreEqual(Points, _g.GetScore());

        _g.GetWorld().IncScore(-Points);
        Assert.AreEqual(0, _g.GetScore());
    }
}