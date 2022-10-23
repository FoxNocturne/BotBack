using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileMapObject tileMapObject;

    [Header("GUI")]
    [SerializeField] private PlayerControler _playerController;
    [SerializeField] private BatterySlider _guiBattery;
    [SerializeField] private RobotWrapperCanvas _guiRobot;

    public List<Robot> listPlayerRobot { get; private set; }
    public List<EnemyObject> listEnemy { get; private set; }
    public List<GadgetObject> listGadget { get; private set; }
    public LevelTimer levelTimer { get; private set; }

    private LevelSerializableRepository _levelRepository;
    private RobotRepository _robotRepository;
    private EnemyRepository _enemyRepository;
    private GadgetRepository _gadgetRepository;
    private int _nbRobotDeath;
    private int _nbRobotGoal;
    private float _maxTime = 180f;

    void Start()
    {
        this._levelRepository = new LevelSerializableRepository();
        this._robotRepository = new RobotRepository();
        this._enemyRepository = new EnemyRepository();
        this._gadgetRepository = new GadgetRepository();
        this._nbRobotDeath = 0;
        this._nbRobotGoal = 0;
        this.levelTimer = new LevelTimer(this._maxTime);
        // this.LoadLevel(this._levelRepository.GetById(GameManager.currentLevelId));
        this.LoadLevel(this._levelRepository.GetById(4));
    }

    public void LoadLevel(LevelSerializable level)
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
        this.levelTimer.onTimeChanged.AddListener(time => this._guiBattery.SetValue(time));
        this.levelTimer.onTimerEnd.AddListener(() => this.OnTimerEnd());
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
