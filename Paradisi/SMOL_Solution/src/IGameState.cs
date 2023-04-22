namespace MySpace;
///<summary>
///Interface for control the state of the game.
///</summary>
public interface IGameState
{
    ///<summary>
    ///If game is Over or not.
    ///</summary>
    bool IsGameOver();

    ///<summary>
    ///Inizialize the game.
    ///</summary>
    void InitGame();

    ///<summary>
    ///Get the score.
    ///</summary>
    ///<returns>the current score</returns>
    int GetScore();

    ///<summary>
    ///Get the current world.
    ///</summary>
    ///<returns>the world</returns>
    World GetWorld();
}