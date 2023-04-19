namespace GameState;

public interface IGameState
{
    bool IsGameOver();

    void InitGame();

    int GetScore();
}