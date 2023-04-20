namespace MySpace;
public class GameState : IGameState
{
    private IWorld _world;
    private IEntity p;

    public GameState()
    {
        _world = new World();
    }

    public int GetScore() => _world.GetScore();

    public void InitGame()
    {
        _world.AddEntity(p);
    }

    public bool IsGameOver()
    {
        return false;
    }
}