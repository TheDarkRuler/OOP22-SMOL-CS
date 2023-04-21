namespace SMOL_Solution;

class GameLoop
{
    private const int Fps = 144;
    private const double FpsInterval = 1_000_000_000 / Fps;

    private const int Ups = 200;
    private const double UpsInterval = 1_000_000_000 / Ups;

    private long _pastTime;
    private double _delta;

    private readonly IGameState _gameState;
    private readonly IGameViewState _gv;
    private readonly IStage _view;

    // ALL commented code is for FPS checking
    /*long timer =0;
    int drawCount=0;*/

    // Constructor for the GameLoop.
    public GameLoop(IGameState gameState, IGameViewState gv, IStage view)
    {
        this._gameState = gameState;
        this._gv = gv;
        this._view = view;
    }
    
    public void Run()
    {
        long now;
        long lastFrame = DateTime.Now.Millisecond;
        _pastTime = DateTime.Now.Millisecond;

        _gameState.InitGame();
        do {
            now = DateTime.Now.Millisecond;

            if (SyncTime(UpsInterval)) {
                Update();
            }

            if ((now - lastFrame) >= FpsInterval) {
                Repaint();
                lastFrame = now;
                //drawCount++;
            } /*
            if (timer >= 1000000000) {
                System.out.println("FPS: "+ drawCount);
                //System.out.println(gameState.getScore());
                drawCount=0;
                timer=0;
            }*/
        } while (!_gameState.IsGameOver());
        _gameState.StopEnemyCreation();

        _gameState.NotifyWrite();
    }

    /**
     * Update the logic of the Game.
     */
    public void Update()
    {
        //Update the logic
    }

    /**
     * Repaint the Window with the change ocurred by the {@link #update()} method.
     */
    private void Repaint()
    {
        //Update the graphics
    }

    // Synchronize the GameLoop with the desired refresh rating.
    private bool SyncTime(double interval)
    {
        long currentTime = DateTime.Now.Millisecond;
        _delta += (currentTime - _pastTime) / interval;
        //timer += (currentTime - pastTime);
        _pastTime = currentTime;
        if (_delta >= 1) {
            _delta--;
            return true;
        }
        return false;
    }
}

internal interface IStage
{
}

internal interface IGameViewState
{
}
