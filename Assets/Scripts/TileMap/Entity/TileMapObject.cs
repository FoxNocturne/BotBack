using UnityEngine;

public class TileMapObject : MonoBehaviour
{
    public Vector2Int size { get; protected set; }
    public TileObject[,] tileMap { get; protected set; }
    protected TileDictionary _tileDictionary;

    public void Awake()
    {
        this._tileDictionary = Resources.Load<TileDictionary>("ScriptableObjects/TileMap/TileDictionary");
    }

    public TileObject[,] InstantiateTileMap(int[,] intTileMap)
    {
        GameObject[,] tileMapPrefab = this.ConvertIntTileMap(intTileMap);
        this.size = new Vector2Int(tileMapPrefab.GetLength(0), tileMapPrefab.GetLength(1));
        this.tileMap = new TileObject[this.size.x, this.size.y];
        for (int x = 0; x < this.size.x; x++)
            for (int y = 0; y < this.size.y; y++)
                this.tileMap[x, y] = TileObject.InstantiateObject(tileMapPrefab[x, y], this, new Vector2Int(x, y));
        for (int x = 0; x < this.size.x; x++)
            for (int y = 0; y < this.size.y; y++)
                this.tileMap[x, y].AfterMapInit();
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

    public TileObject GetTileAt(Vector2Int mapPos) {
        return this.tileMap[mapPos.x, mapPos.y];
    }

    // check at coord if the tile is walkable
    public bool checkgo(Vector2Int coord)
    {
        return (GetTileAt(coord).isWalkable);
    }

    public bool checkKill(Vector2Int coord)
    {
        return (GetTileAt(coord).isKill);
    }

    public bool checkWin(Vector2Int coord)
    {
        return (GetTileAt(coord).isWin);
    }

    public bool checkFire(Vector2Int coord)
    {
        return (GetTileAt(coord).isFire);
    }

    public bool checkVoid(Vector2Int coord)
    {
        return (GetTileAt(coord).isVoid);
    }
}
