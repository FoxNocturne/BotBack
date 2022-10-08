﻿using UnityEngine;
using System.Collections.Generic;

public class TileMapRepository
{
    public static TileMapRepository instance
    {
        get { 
            if (TileMapRepository._instance == null) TileMapRepository._instance = new TileMapRepository();
            return TileMapRepository._instance;
        }
    }
    private static TileMapRepository _instance;

    private List<int[,]> TILE_MAPS = new List<int[,]>();

    public TileMapRepository()
    {
        this.TILE_MAPS.Add(
            new int[,] {
                // Room 1
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 4, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 1, 0, 1, 4, 1, 0, 1, 3, 1 },
                { 1, 0, 0, 2, 2, 2, 0, 0, 4, 3, 4, 0, 2, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 4, 0, 0, 4, 3, 3, 0, 2, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 4, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 2, 2, 2, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 4, 0, 0, 0, 0, 1, 3, 1, 0, 1, 4, 1, 0, 1, 3, 1 },
                { 1, 0, 0, 0, 0, 0, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                // Room 2
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 3, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 4, 4, 4, 0, 0, 3, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 3, 3, 3, 3, 0, 0, 0, 3, 3, 0, 1, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 3, 3, 3, 0, 0, 0, 0, 3, 3, 1, 1, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 3, 3, 0, 0, 0, 0, 3, 3, 3, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 1, 1, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 1, 0, 4, 3, 2, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                // Room 3
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            }
        );
       
    }

    public int[,] GetTileMapById(int index)
    {
        return this.TILE_MAPS[index];
    }
}