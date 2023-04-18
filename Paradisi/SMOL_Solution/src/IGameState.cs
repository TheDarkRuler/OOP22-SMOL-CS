namespace SMOL_Solution;

public interface IGameState
{
    bool IsGameOver();

    void InitGame();

    int GetScore();
}