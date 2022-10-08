using UnityEngine;

public class TileMapObject : MonoBehaviour
{
    public Vector2Int size { get; protected set; }
    public GameObject tilePrefab;
    public TileObject[,] tileMap { get; protected set; }
    protected TileDictionary _tileDictionary;

    public void Awake()
    {
        this._tileMapRepository = new TileMapRepository();
        this.InstantiateTileMap(this._tileMapRepository.GetTileMapById(0));
        //this.InstantiateTileMap(this._tileMapRepository.GetTileMapById(1));
    }

    public TileObject[,] InstantiateTileMap(int[,] intTileMap)
    {
        GameObject[,] tileMapPrefab = this.ConvertIntTileMap(intTileMap);
        this.size = new Vector2Int(tileMapPrefab.GetLength(0), tileMapPrefab.GetLength(1));
        this.tileMap = new TileObject[this.size.x, this.size.y];
        for (int x = 0; x < this.size.x; x++)
            for (int y = 0; y < this.size.y; y++)
                this.tileMap[x, y] = TileObject.InstantiateObject(tileMapPrefab[x, y], this, new Vector2Int(x, y));
        return this.tileMap;
    }

    public GameObject[,] ConvertIntTileMap(int[,] intTileMap)
    {
        GameObject[,] tileMap = new GameObject[intTileMap.GetLength(1), intTileMap.GetLength(0)];
        for (int y = 0; y < intTileMap.GetLength(0); y++)
            for (int x = 0; x < intTileMap.GetLength(1); x++)
                tileMap[x, y] = this._tileDictionary.GetById(intTileMap[y, x]);
        return tileMap;
    }
}
