namespace MySpace;
///<summary>
///The implementation of the GameState interface.
///</summary>
public class GameState : IGameState
{
    private World _world;

    ///<summary>
    ///Set the game world.
    ///</summary>
    ///<param name = "world"></param>
    public GameState(World world)
    {
        _world = world;
    }

    ///<inheritdoc />
    public int GetScore() => _world.GetScore();

    ///<inheritdoc />
    public void InitGame()
    {
        _world.AddEntity(new Entity(Type.HEALTH));
        _world.AddEntity(new Entity(Type.PLAYER));
        _world.AddEntity(new Entity(Type.WALL));
        _world.AddEntity(new Entity(Type.WEAPON));
    }

    ///<inheritdoc />
    public bool IsGameOver()
    {
        return !_world.GetEntities().Where(e => e.GetType() == Type.HEALTH).Any();
    }

    ///<inheritdoc />
    public World GetWorld() => _world;
}