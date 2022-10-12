using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileMapObject tileMapObject;
    [SerializeField] private LevelDictionary _levelDictionary;

    [Header("GUI")]
    [SerializeField] private PlayerControler _playerController;
    [SerializeField] private BatterySlider _guiBattery;
    [SerializeField] private RobotWrapperCanvas _guiRobot;


    public float timeRemaining { get; private set; } = 100;
    public List<Robot> listPlayerRobot { get; private set; }
    private LevelSerializableRepository _levelRepository;
    private RobotRepository _robotRepository;

    void Start()
    {
        this._levelRepository = new LevelSerializableRepository();
        this._robotRepository = new RobotRepository();
        this.LoadLevel(this._levelRepository.GetById(GameManager.currentLevelId));
    }

    void Update()
    {
        this._guiBattery.SetValue(BotBackManager.GlobalTimer.GetTimerPcInv());
    }

    public void LoadLevel(LevelSerializable level)
    {
        // Instancier la carte
        this.tileMapObject.InstantiateTileMap(level.GetIntTileMap());

        // Instancier les robots
        this.listPlayerRobot = new List<Robot>();
        foreach (var spawn in level.listRobotSpawn) {
            TileObject spawnTransform = this.tileMapObject.tileMap[spawn.x, spawn.y];
            Robot newRobot = Robot.InstantiateObject(this._robotRepository.GetById(spawn.robotId), spawnTransform, _playerController);
            this._guiRobot.AddRobot(newRobot);
            this.listPlayerRobot.Add(newRobot);
            newRobot.markerObject.SetOrder(this.listPlayerRobot.Count);
        }
        this._playerController.SetListRobot(this.listPlayerRobot);

        // Initialiser la UI
        this._guiBattery.SetMaxValue(100);
    }
}
