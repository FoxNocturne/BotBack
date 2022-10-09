using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileMapObject tileMapObject;
    [SerializeField] private LevelScript levelScript;

    [Header("UI")]
    [SerializeField] private RobotWrapperCanvas _robotWrapperCanvas;
    [SerializeField] private PlayerControler _playerController;

    public float timeRemaining { get; private set; } = 100;
    public List<Robot> _listPlayerRobot;

    void Start()
    {
        this.LoadLevel(this.levelScript);
    }

    public void LoadLevel(LevelScript levelScript)
    {
        // Instancier la carte
        this.tileMapObject.InstantiateTileMap(levelScript.intTileMap);

        // Instancier les robots
        this._listPlayerRobot = new List<Robot>();
        foreach (LevelRobotSpawn spawn in levelScript.listRobotSpawn) {
            TileObject spawnTransform = this.tileMapObject.GetTileAt(spawn.mapPos);
            Robot newRobot = Robot.InstantiateObject(spawn.robotPrefab, spawnTransform);
            this._listPlayerRobot.Add(newRobot);
            this._robotWrapperCanvas.AddRobot(newRobot);
        }
        this._playerController.SetListRobot(this._listPlayerRobot);
    }
}
