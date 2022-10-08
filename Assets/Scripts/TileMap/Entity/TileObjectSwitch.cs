using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectSwitch : TileObject
{
    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
    }
}
