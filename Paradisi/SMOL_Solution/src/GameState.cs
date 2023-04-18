using SMOL_Solution;

class GameState : IGameState
{
    private IWorld _world;
    public int GetScore() => _world.GetScore();

    public void InitGame()
    {
        //_world.AddEntity();  
    }

    public bool IsGameOver()
    {
        return false;
    }
}