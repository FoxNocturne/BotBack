using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileMapObject tileMapObject;

    public LevelScript levelScript;
    public float timeRemaining { get; private set; } = 100;

    // Start is called before the first frame update
    void Start()
    {
        this.LoadLevel(this.levelScript);
    }

    public void LoadLevel(LevelScript levelScript)
    {
        this.tileMapObject.InstantiateTileMap(levelScript.intTileMap);
    }
}
