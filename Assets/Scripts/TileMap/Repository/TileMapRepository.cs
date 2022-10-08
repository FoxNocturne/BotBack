using UnityEngine;
using System.Collections.Generic;

public class TileMapRepository
{
    private List<int[,]> TILE_MAPS = new List<int[,]>();
    private TileDictionary _tileDictionary;

    public TileMapRepository()
    {
        this._tileDictionary = Resources.Load<TileDictionary>("ScriptableObjects/TileMap/TileDictionary");
        this.TILE_MAPS.Add(
            new int[,] {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            }
        ); ;
    }

    public GameObject[,] GetTileMapById(int index) {
        int[,] intTileMap = this.TILE_MAPS[index];
        GameObject[,] tileMap = new GameObject[intTileMap.GetLength(0), intTileMap.GetLength(1)];
        for (int x = 0; x < intTileMap.GetLength(0); x++)
            for (int y = 0; y < intTileMap.GetLength(1); y++)
                tileMap[x, y] = this._tileDictionary.GetById(intTileMap[x, y]);
        return tileMap;
    }
}