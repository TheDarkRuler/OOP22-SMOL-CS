namespace SMOL_Solution;

class GameLoop
{
    private const int Fps = 144;
    private const double FpsInterval = 1_000_000_000 / Fps;

    private const int Ups = 200;
    private const double UpsInterval = 1_000_000_000 / Ups;

    private long _pastTime;
    private double _delta;

    private readonly GameState _gameState;
    private readonly GameViewState _gv;
    private readonly Stage _view;

    // ALL commented code is for FPS checking
    /*long timer =0;
    int drawCount=0;*/

    /**
     * Constructor for the GameLoop.
     * @param gameState the state of the game
     * @param gv the visual rappresentation of the game
     * @param view The stage of the current view
     */
    public GameLoop(GameState gameState, GameViewState gv, Stage view) {
        this._gameState = gameState;
        this._gv = gv;
        this._view = view;
    }

    /**
     * Override of the {@code run()} method in the {@link Thread} class.
     * This implements the main body of the GameLoop
     */
    public void Run() {
        long now;
        long lastFrame = DateTime.Now.Millisecond;
        _pastTime = DateTime.Now.Millisecond;

        _gameState.InitGame();
        if (_gameState.GetScoreLocalStorage().GetScoreFile().CanRead) {
            _gameState.NotifyRead();
        }
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

        new WindowImpl(new GameOverWinState(_gameState.GetScore(), _gameState.GetSkins())).Launch(_view);
    }

    /**
     * Update the logic of the Game.
     */
    public void Update() {
        //gameState.getWorld().updateWorld();
    }

    /**
     * Repaint the Window with the change ocurred by the {@link #update()} method.
     */
    private void Repaint() {
            //gv.render(view);
    }

    /**
     *  Syncronize the {@link GameLoop} with the desired refresh rating ({@value #UPS}).
     * @param interval : the time span of the refresh rate expressed in nanosecond
     * @return {@code True} if the time passed is equal or more of the desired {@link #DRAW_INTERVAL};
     * Otherwise {@code False}.
     */
    private bool SyncTime(double interval) {
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

internal class GameOverWinState
{
    private int _score;
    private String _skin; 
    public GameOverWinState(int score, String skin)
    {
        _score = score;
        _skin = skin;
    }
}

internal class WindowImpl
{
    private GameOverWinState _state;
    public WindowImpl(GameOverWinState state)
    {
        _state = state;
    }

    public void Launch(Stage s)
    {
        
    }
}

internal interface Stage
{
}

internal interface GameViewState
{
}

internal interface GameState
{
    bool IsGameOver();

    void InitGame();

    int GetScore();

    String GetSkins();

    void StopEnemyCreation();

    void NotifyWrite();

    void NotifyRead();

    LocalStorage GetScoreLocalStorage();


}

internal interface LocalStorage
{
    FileStream GetScoreFile();
}
