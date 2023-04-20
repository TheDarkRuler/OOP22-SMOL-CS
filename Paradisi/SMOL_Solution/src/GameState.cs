namespace MySpace;
public class GameState : IGameState
{
    private World _world;
    public GameState(World w)
    {
        _world = w;
    }

    public int GetScore() => _world.GetScore();
    public void InitGame()
    {
        _world.AddEntity(new Entity(Type.HEALTH));
        _world.AddEntity(new Entity(Type.PLAYER));
        _world.AddEntity(new Entity(Type.WALL));
        _world.AddEntity(new Entity(Type.WEAPON));
    }

    public bool IsGameOver()
    {
        return !_world.GetEntities().Where(e => e.GetType() == Type.HEALTH).Any();
    }

    public World GetWorld() => _world;
}