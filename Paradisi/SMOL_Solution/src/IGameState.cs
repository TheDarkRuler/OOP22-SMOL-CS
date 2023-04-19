namespace MySpace;
public interface IGameState
{
    bool IsGameOver();

    void InitGame();

    int GetScore();
}