namespace smol.stub;

public class GameState : IGameState
{
    private IWorld World { get; }

    public GameState(IWorld world)
    {
        World = world;
    }
    public IWorld? GetWorld()
    {
        return World;
    }
}