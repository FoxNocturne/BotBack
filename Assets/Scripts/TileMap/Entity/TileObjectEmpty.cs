using System.Collections;
using UnityEngine;

public class TileObjectEmpty : TileObject
{
    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = false;
        this.isFlyable = true;
        this.isKill = false;
        this.isWin = false;
        this.isFire = false;
        this.isVoid = true;
    }
}