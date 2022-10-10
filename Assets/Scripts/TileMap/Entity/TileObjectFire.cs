using System.Collections;
using UnityEngine;

public class TileObjectFire: TileObject
{
    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
        this.isFlyable = true;
        this.isKill = false;
        this.isWin = false;
        this.isFire = true;
        this.isVoid = false;
    }
}