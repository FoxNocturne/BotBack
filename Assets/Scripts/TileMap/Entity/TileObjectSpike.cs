using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectSpike : TileObject
{

    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
        this.isKill = true;
        this.isWin = false;
    }
}
