using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectPortal : TileObject, ITileDrillable
{
    public TileObjectPortal linkedPortal { get; private set; }

    /// <summary>
    /// Setup tile's specific variables.
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
        this.isFlyable = true;
        this.isKill = false;
        this.isWin = false;
        this.isFire = false;
        this.isVoid = false;
        this.isGadgetAllowed = false;
    }

    public override void AfterMapInit()
    {
        this.linkedPortal = this.FindOtherSide();
    }

    /// <summary>
    /// Check that the tile can be drilled.
    /// </summary>
    /// <returns></returns>
    public bool IsDrillable()
    {
        return this.linkedPortal != null;
    }

    /// <summary>
    /// Find the exiting drillable tile.
    /// </summary>
    /// <returns></returns>
    private TileObjectPortal FindOtherSide()
    {
        for (int x = 0; x < this.tileMapObject.size.x; x++) {
            for (int y = 0; y < this.tileMapObject.size.y; y++) {
                if ((x != this.tileMapPos.x && y != this.tileMapPos.y) || (x == this.tileMapPos.x && y == this.tileMapPos.y)) {
                    continue;
                }
                TileObject tile = this.tileMapObject.GetTileAt(new Vector2Int(x, y));
                if (tile != null && typeof(TileObjectPortal) == tile.GetType()) {
                    return (TileObjectPortal)tile;
                }                
            }
        }
        return null;
    }
}
