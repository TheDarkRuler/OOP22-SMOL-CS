namespace SMOL_Solution;

public interface IGameState
{
    ///<value>The current world </value>
    //public World? GetWorld() { get; }

    public Boolean IsGameOver();

    public int getScore();

}