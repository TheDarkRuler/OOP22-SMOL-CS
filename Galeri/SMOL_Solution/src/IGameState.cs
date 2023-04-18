namespace SMOL_Solution;

public interface IGameState
{
    bool IsGameOver();

    void InitGame();

    int GetScore();

    String GetSkins();

    void StopEnemyCreation();

    void NotifyWrite();

    void NotifyRead();
    
}
