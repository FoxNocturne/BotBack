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

    void Start()
    {
        this.LoadLevel(this._levelDictionary.GetById(0));
    }

    void Update()
    {
        this._guiBattery.SetValue(BotBackManager.GlobalTimer.GetTimerPcInv());
    }

    public void LoadLevel(LevelScript levelScript)
    {
        // Instancier la carte
        this.tileMapObject.InstantiateTileMap(levelScript.intTileMap);

        // Instancier les robots
        this.listPlayerRobot = new List<Robot>();
        foreach (LevelRobotSpawn spawn in levelScript.listRobotSpawn) {
            TileObject spawnTransform = this.tileMapObject.GetTileAt(spawn.mapPos);
            Robot newRobot = Robot.InstantiateObject(spawn.robotPrefab, spawnTransform, _playerController);
            this._guiRobot.AddRobot(newRobot);
            this.listPlayerRobot.Add(newRobot);
        }
        this._playerController.SetListRobot(this.listPlayerRobot);

        // Initialiser la UI
        this._guiBattery.SetMaxValue(100);
    }
}
