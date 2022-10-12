using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marche : Robot
{
    private void Update()
    {
        this.Move();
    }

    public override void Action() { }

    protected override bool CanGoOnTile(TileObject tile)
    {
        return tile.isWalkable;
    }
}
