using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectWall : TileObject
{

    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = false;
        this.isKill = false;
        this.isWin = false;
    }
}
