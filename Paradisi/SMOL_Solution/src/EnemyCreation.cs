namespace MySpace;

using System.Timers;
using System.Collections.Generic;
using System;
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
    /** Default max time of spawn.*/
    public const int DEF_MAX_TIME_SPAWN = 3500;
    /** Default minimum time of spawn.*/
    public const int DEF_MIN_TIME_SPAWN = 2500;
    private GameState _gameState;
    private Dictionary<String, Double> _entities;
    private Timer _createEnemyTimer;
    private int _difficultyLevel;
    private int _minTimeEnemySpawn;
    private int _maxTimeEnemySpawn;
    private Random random = new Random();

    public EnemyCreation(GameState gameState)
    {
        _gameState = gameState;
        _entities = new Dictionary<string, double>();
        _entities.Add("Mole", DEF_RATE_BASIC);
        _entities.Add("Helmet_mole", DEF_RATE_HELMET);
        _entities.Add("Angry_mole", DEF_RATE_ANGRY);
        _entities.Add("Bomb_mole", DEF_RATE_BOMB);

        _minTimeEnemySpawn = DEF_MIN_TIME_SPAWN;
        _maxTimeEnemySpawn = DEF_MAX_TIME_SPAWN;
        _difficultyLevel = 0;
    }

    /**
     * Change the spawn rate of the enemies and the time spawn between two moles.
     */
    /*private void ChangeDifficulty()
    {
        int temp = _gameState.GetScore() / INC_DIFFICULTY_PIVOT;
        _entitiesMap.put("Angry_mole", DEF_RATE_ANGRY + (temp * INC_RATE_ANGRY));
        _entitiesMap.put("Helmet_mole", DEF_RATE_HELMET + (temp * INC_RATE_HELMET));
        _minTimeEnemySpawn = DEF_MIN_TIME_SPAWN - temp * DEC_TIME_SPAWN;
        _maxTimeEnemySpawn = DEF_MAX_TIME_SPAWN - temp * DEC_TIME_SPAWN;
        _difficultyLevel++;
        this.createEnemyTimer.cancel();
        creationTimer();
    }*/
    private void CreationTimer() {

        Timer _createEnemyTimer = new System.Timers.Timer(_maxTimeEnemySpawn - _minTimeEnemySpawn);
        //createEnemyTimer.Elapsed = Run();

            /*void Run() {
                if (gameState.getScore() / INC_DIFFICULTY_PIVOT <= DIFFICULTY_LIMIT
                    && difficultyLevel < gameState.getScore() / INC_DIFFICULTY_PIVOT) {
                    changeDifficulty();
                }
                List<Double> weightList = new ArrayList<>(entitiesMap.values().stream().sorted().toList());
                Double randomDouble = Math.random();


                SpawnEntity(entitiesMap.entrySet()
                    .stream()
                    .filter(s -> s.getValue().equals(weightList.stream().sorted()
                        .filter(x -> x >= randomDouble)
                        .findFirst().get()))
                    .findAny().get().getKey());
            }*/

    }

    /**
     * Spawn the enemy.
     * @param enemyName : the name of the enemy
     */
    /*private void SpawnEntity(String enemyName) {
        switch (enemyName) {
            case "Mole":
                gameState.getWorld().orElseThrow()
                    .addEntity(gameState.getEntityFactory()
                        .createBasicEnemy(initialEnemyPosition(), gameState.getWorld().orElseThrow()));
                break;
            case "Helmet_mole":
                gameState.getWorld().orElseThrow()
                    .addEntity(gameState.getEntityFactory()
                        .createHelmetEnemy(initialEnemyPosition(), gameState.getWorld().orElseThrow()));
                break;
            case "Angry_mole":
                gameState.getWorld().orElseThrow()
                    .addEntity(gameState.getEntityFactory()
                        .createAngryEnemy(initialEnemyPosition(), gameState.getWorld().orElseThrow()));
                break;
            case "Bomb_mole":
                gameState.getWorld().orElseThrow()
                    .addEntity(gameState.getEntityFactory()
                        .createBombEnemy(initialEnemyPosition(), gameState.getWorld().orElseThrow()));
                break;
            default:
                break;
        }
    }
    public void StopCreation() {
        _createEnemyTimer.Cancel();
    }

    /**
     * starts the creation of the enemies.
     */
    public void StartCreation() {
        CreationTimer();
    }
}