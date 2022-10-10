using System.Collections;
using UnityEngine;

public class TileObjectDoor : TileObject
{
    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = false;
        this.isFlyable = false;
        this.isKill = false;
        this.isWin = false;
        this.isFire = false;
        this.isVoid = true;
    }
}