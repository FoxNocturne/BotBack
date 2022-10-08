using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRobotSpawn
{
    public Vector2Int mapPos { get; private set; }
    public IRobot robotPrefab { get; private set; }

    public LevelRobotSpawn(Vector2Int mapPos, IRobot robot)
    {
        this.mapPos = mapPos;
        this.robotPrefab = robot;
    }
}
