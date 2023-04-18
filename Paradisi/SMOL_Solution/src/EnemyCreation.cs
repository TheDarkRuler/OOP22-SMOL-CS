namespace SMOL_Solution;

class EnemyCreation
{
    /** Default spawn rate for basic enemy. */
    public const double DEF_RATE_BASIC = 1.0;
    /** Default spawn rate for helmet enemy.*/
    public const double DEF_RATE_HELMET = 0.45;
    /** Default spawn rate for angry enemy.*/
    public const double DEF_RATE_ANGRY = 0.325;
    /** Default spawn rate for bomb enemy.*/
    public const double DEF_RATE_BOMB = 0.2;
    private GameState _gameState;
    private Dictionary<String, Double> _entities;
    private Timer _createEnemyTimer;
    private int _difficultyLevel;
    private int _minTimeEnemySpawn;
    private int _maxTimeEnemySpawn;

    public EnemyCreation(GameState gameState)
    {
        _gameState = gameState;
        _entities = new Dictionary<string, double>();
        _entities.Add("Mole", DEF_RATE_BASIC);
        _entities.Add("Helmet_mole", DEF_RATE_HELMET);
        _entities.Add("Angry_mole", DEF_RATE_ANGRY);
        _entities.Add("Bomb_mole", DEF_RATE_BOMB);

       /* _minTimeEnemySpawn = DEF_MIN_TIME_SPAWN;
        _maxTimeEnemySpawn = DEF_MAX_TIME_SPAWN;*/
        _difficultyLevel = 0;
    }
}