using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileMapObject tileMapObject;
    [SerializeField] private LevelScript levelScript;

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
        foreach (LevelRobotSpawn spawn in levelScript.listRobotSpawn) {
            Transform spawnTransform = this.tileMapObject.GetTileAt(spawn.mapPos).transform;
            GameObject.Instantiate(spawn.robotPrefab.gameObject, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
