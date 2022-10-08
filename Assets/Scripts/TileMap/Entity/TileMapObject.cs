using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapObject : MonoBehaviour
{
    public Vector2Int size { get; protected set; }
    public GameObject tilePrefab;
    public TileObject[,] tileMap { get; protected set; }

    private TileMapRepository _tileMapRepository;
    
    public void Start()
    {
        this._tileMapRepository = new TileMapRepository();
        this.InstantiateTileMap(this._tileMapRepository.GetTileMapById(0));
        //this.InstantiateTileMap(this._tileMapRepository.GetTileMapById(1));
    }

    public TileObject[,] InstantiateTileMap(GameObject[,] tileMapPrefab)
    {
        this.size = new Vector2Int(tileMapPrefab.GetLength(0), tileMapPrefab.GetLength(1));
        this.tileMap = new TileObject[this.size.x, this.size.y];
        for (int x = 0; x < this.size.x; x++)
            for (int y = 0; y < this.size.y; y++)
                this.tileMap[x, y] = TileObject.InstantiateObject(tileMapPrefab[x, y], this, new Vector2Int(x, y));
        return this.tileMap;
    }
}
