using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelSerializable
{
    public int levelId;
    public LevelSerializableTileMapRow[] tileMap;
    public LevelSerializableEntitySpawn[] listRobotSpawn;
    public LevelSerializableEntitySpawn[] listEnemySpawn;

    public int[,] GetIntTileMap() {
        int[,] output = new int[this.tileMap.Length, this.tileMap[0].tileRow.Length];
        for (int x = 0; x < this.tileMap.Length; x++) {
            for (int y = 0; y < this.tileMap[x].tileRow.Length; y++) {
                output[x, y] = this.tileMap[x].tileRow[y];
            }
        }
        return output;
    }
}

[Serializable]
public class LevelSerializableEntitySpawn
{
    public int robotId;
    public int x;
    public int y;
}

[Serializable]
public class LevelSerializableTileMapRow
{
    public int[] tileRow;
}