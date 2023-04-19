namespace GameState;

class GameState : IGameState
{
    private IWorld _world;
    private IEntity p;
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