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
    }
}