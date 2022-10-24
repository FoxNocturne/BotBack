using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    public static LevelSceneManager instance { get; private set; }

    [Header("World Game Objects")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileMapObject tileMapObject;

    [Header("GUI")]
    [SerializeField] private PlayerControler _playerController;
    [SerializeField] private BatterySlider _guiBattery;
    [SerializeField] private RobotWrapperCanvas _guiRobot;
    [SerializeField] private ScoreCanvas _guiScore;
    [SerializeField] private LevelUIWorldMessageCanvas _guiWorldMessage;

    public List<Robot> listPlayerRobot { get; private set; }
    public List<EnemyObject> listEnemy { get; private set; }
    public List<GadgetObject> listGadget { get; private set; }
    public LevelTimer levelTimer { get; private set; }
    public LevelScorer levelScorer { get; private set; }

    private LevelSerializableRepository _levelRepository;
    private RobotRepository _robotRepository;
    private EnemyRepository _enemyRepository;
    private GadgetRepository _gadgetRepository;
    private int _nbRobotDeath;
    private int _nbRobotGoal;
    private float _maxTime = 180f;

    void Start()
    {
        LevelSceneManager.instance = this;
        this._levelRepository = new LevelSerializableRepository();
        this._robotRepository = new RobotRepository();
        this._enemyRepository = new EnemyRepository();
        this._gadgetRepository = new GadgetRepository();
        this._nbRobotDeath = 0;
        this._nbRobotGoal = 0;
        this.levelTimer = new LevelTimer(this._maxTime);
        this.levelScorer = new LevelScorer();

        this.LoadLevel(this._levelRepository.GetById(GameManager.currentLevelId));
    }

    void OnDestroy()
    {
        LevelSceneManager.instance = null;
    }

    private void LoadLevel(LevelSerializable level)
    {
        // Instantiate map
        this.tileMapObject.InstantiateTileMap(level.GetIntTileMap());

        // Instantiate robots
        this.listPlayerRobot = new List<Robot>();
        foreach (var spawn in level.listRobotSpawn) {
            TileObject spawnTransform = this.tileMapObject.tileMap[spawn.x, spawn.y];
            Robot newRobot = Robot.InstantiateObject(this._robotRepository.GetById(spawn.id), spawnTransform);
            newRobot.onDeath.AddListener(() => { this.OnRobotDeath(newRobot); });
            newRobot.onGoal.AddListener(() => { this.OnRobotGoal(newRobot); });
            this._guiRobot.AddRobot(newRobot);
            this.listPlayerRobot.Add(newRobot);
            newRobot.markerObject.SetOrder(this.listPlayerRobot.Count);
        }
        this._playerController.SetListRobot(this.listPlayerRobot);

        // Instantiate enemies
        this.listEnemy = new List<EnemyObject>();
        foreach (var spawn in level.listEnemySpawn) {
            TileObject spawnTransform = this.tileMapObject.tileMap[spawn.x, spawn.y];
            EnemyObject newEnemy = EnemyObject.InstantiateObject(this._enemyRepository.GetById(spawn.id), spawnTransform);
            newEnemy.ApplyStrategy(spawn);
            this.listEnemy.Add(newEnemy);
        }

        // Instantiate gadgets
        this.listGadget = new List<GadgetObject>();
        foreach (var spawn in level.listGadgetSpawn) {
            TileObject spawnTransform = this.tileMapObject.tileMap[spawn.x, spawn.y];
            GadgetObject newGadget = GadgetObject.InstantiateObject(this._gadgetRepository.GetById(spawn.id), spawnTransform);
            this.listGadget.Add(newGadget);
        }

        // Initialiser la UI
        this._guiBattery.SetMaxValue(this.levelTimer.remainingTime);
        this.levelTimer.onTimeChanged.AddListener(this._guiBattery.SetValue);
        this.levelTimer.onTimerEnd.AddListener(this.OnTimerEnd);
        this.levelScorer.onScoreChanged.AddListener(variation => this._guiScore.SetValue(this.levelScorer.currentScore));
        this.levelScorer.onScoreChangePrinted.AddListener(this._guiWorldMessage.PrintScore);

        StartCoroutine(this.levelTimer.RunTimer());
    }

    private void OnRobotGoal(Robot robot)
    {
        this._nbRobotGoal++;
        if (this._nbRobotGoal + this._nbRobotDeath == this.listPlayerRobot.Count) {
            this.FinishLevel();
        }
    }

    private void OnRobotDeath(Robot robot)
    {
        this._nbRobotDeath++;
        if (this._nbRobotGoal + this._nbRobotDeath == this.listPlayerRobot.Count) {
            this.FinishLevel();
        }
    }

    private void FinishLevel()
    {
        this.levelTimer.Pause();
        if (this._nbRobotGoal > 0) {
            LevelScoreComputer computer = new LevelScoreComputer();
            computer.baseScore = this.levelScorer.currentScore;
            computer.nbRobot = this.listPlayerRobot.Count;
            computer.nbRobotSaved = this._nbRobotGoal;
            computer.timeMax = this._maxTime;
            computer.timeRemaining = this.levelTimer.remainingTime;
            computer.hasStopped = this._playerController.hasStopped;
            QuestClearSceneManager.LoadScene(computer);
        }
        else { SceneManager.LoadScene("GameOver"); }
    }

    private void OnTimerEnd()
    {
        SceneManager.LoadScene("GameOver");
    }
}
